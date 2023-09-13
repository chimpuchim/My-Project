using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;


public class PlayerYardController : MonoBehaviour
{
    public static PlayerYardController Instance;
    
    [SerializeField] private List<GameObject> playerYards;
    public List<GameObject> PlayerYards
    {
        get => playerYards;
    }
    
    [SerializeField] private List<GameObject> playerYardsEmpty;
    public List<GameObject> PlayerYardsEmpty
    {
        get => playerYardsEmpty;
    }
    
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }    
        else
        {
            Destroy(this);
        }
        
        SetupUnitStart();
    }

    private void SetupUnitStart()
    {
        foreach (GameObject playerYard in playerYards)
        {
            if (PlayerPrefs.HasKey(playerYard.name))
            {
                if (SaveManager.GetInstance().LoadStringData(playerYard.name) == "None")
                {
                    foreach (Transform childTransform in playerYard.transform.GetChild(0))
                    {
                       childTransform.gameObject.SetActive(false);
                    }
                    foreach (Transform childTransform in playerYard.transform.GetChild(1))
                    {
                       childTransform.gameObject.SetActive(false);
                    }
                }
                else
                {
                    string[] parts = SaveManager.GetInstance().LoadStringData(playerYard.name).Split(',');
                    
                    string typeUnit = parts[1];
                    string unitNumber = parts[2];

                    if (typeUnit == "Melee")
                    {
                        playerYard.transform.GetChild(0).GetChild(int.Parse(unitNumber) - 1).gameObject.SetActive(true);
                    }
                    else
                    {
                        playerYard.transform.GetChild(1).GetChild(int.Parse(unitNumber) - 1).gameObject.SetActive(true);
                    }
                }
            }
        }
        
        YardEmptyToList();
    }

    public void YardEmptyToList()
    {
        playerYardsEmpty.Clear();
        
        foreach (GameObject playerYard in playerYards)
        {
            if (playerYard.GetComponent<PlayerYard>().CheckEmpty())
            {
                playerYardsEmpty.Add(playerYard);
                SaveManager.GetInstance().SaveStringData(playerYard.name, "None");
            }
            else
            {
                SaveManager.GetInstance().SaveStringData(playerYard.name, playerYard.name + "," + playerYard.GetComponent<PlayerYard>().UnitActive.name.Substring(0, 5)+ "," + Regex.Match(playerYard.GetComponent<PlayerYard>().UnitActive.name, @"\d+").Value);
            }
        }
    }

    public void BuyUnit(string name)
    {
        if (playerYardsEmpty.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, playerYardsEmpty.Count);
            GameObject randomObject = playerYardsEmpty[randomIndex];
            
            if (name == "Melee")
            {
                randomObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                YardEmptyToList();
                PlayerController.Instance.FindAndAddPlayers();
            }

            if (name == "Range")
            {
                randomObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
                YardEmptyToList();
                PlayerController.Instance.FindAndAddPlayers();
            }
        }
    }
}

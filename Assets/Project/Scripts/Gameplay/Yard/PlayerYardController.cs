using System;
using System.Collections;
using System.Collections.Generic;
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
            }
        }
    }

    public void BuyUnit(string name)
    {
        if (playerYardsEmpty != null)
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

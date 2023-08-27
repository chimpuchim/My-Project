using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
        foreach (GameObject playerYard in playerYards)
        {
            if (playerYard.GetComponent<PlayerYard>().CheckEmpty() == true)
            {
                playerYardsEmpty.Add(playerYard);
            }
        }
    }
}

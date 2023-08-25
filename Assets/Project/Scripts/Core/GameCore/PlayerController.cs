using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    [SerializeField] private List<GameObject> playerUnits = new List<GameObject>();
    public List<GameObject> PlayerUnits
    {
        get => playerUnits;
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
        
        FindAndAddPlayers();
    }
    
    private void FindAndAddPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            playerUnits.Add(player);
        }
    }
}

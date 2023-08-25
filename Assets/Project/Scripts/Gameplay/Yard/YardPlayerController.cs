using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class YardPlayerController : MonoBehaviour
{
    public static YardPlayerController Instance;
    
    [SerializeField] private List<GameObject> playerYards = new List<GameObject>();
    
    public List<GameObject> PlayerYards
    {
        get => playerYards;
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

        FindAndAddYards();
    }
    
    private void FindAndAddYards()
    {
        GameObject[] yards = GameObject.FindGameObjectsWithTag("Yard");

        foreach (GameObject yard in yards)
        {
            playerYards.Add(yard);
        }
    }
}

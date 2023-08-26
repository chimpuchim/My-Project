using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class YardPlayerController : MonoBehaviour
{
    public static YardPlayerController Instance;
    
    [SerializeField] private List<BoxCollider2D> playerYards = new List<BoxCollider2D>();
    
    public List<BoxCollider2D> PlayerYards
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
    }
}

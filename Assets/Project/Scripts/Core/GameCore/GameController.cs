using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private EnemyController enemyController;

    [SerializeField] private bool isStartBattle;
    public bool IsStartBattle
    {
        get => isStartBattle;
        set => isStartBattle = value;
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

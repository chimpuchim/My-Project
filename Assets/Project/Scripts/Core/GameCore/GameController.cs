using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private int coinLevel;
    public int CoinLevel
    {
        get => coinLevel;
        set => coinLevel = value;
    }

    private bool isStartBattle;
    public bool IsStartBattle
    {
        get => isStartBattle;
        set => isStartBattle = value;
    }
    
    private bool isEnd;
    public bool IsEnd
    {
        get => isEnd;
        set => isEnd = value;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;
    
    [SerializeField] private List<GameObject> enemyUnits = new List<GameObject>();
    public List<GameObject> EnemyUnits
    {
        get => enemyUnits;
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
        
        FindAndAddEnemies();
    }
    
    private void FindAndAddEnemies()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemys)
        {
            enemyUnits.Add(enemy);
        }
    }
}

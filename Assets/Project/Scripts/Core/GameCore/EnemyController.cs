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
    
    public void FindAndAddEnemies()
    {
        enemyUnits.Clear();
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemys)
        {
            UnitController unitController = enemy.transform.parent.GetComponent<UnitController>();
            enemyUnits.Add(enemy);
            unitController.TargetPos = FindClosestPlayer(enemy).transform;
        }
    }
    
    GameObject FindClosestPlayer(GameObject enemy)
    {
        string nameUnit = enemy.name.Substring(5, 5);
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject closestPlayer = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = Vector2.zero;
        
        if (nameUnit == "Melee")
        {
            currentPosition = enemy.transform.parent.GetComponent<UnitMeleeController>().UnitMeleeModel.transform.position;
        }

        if (nameUnit == "Range")
        {
            currentPosition = enemy.transform.parent.GetComponent<UnitRangeController>().UnitRangeModel.transform.position;
        }
        
        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector3.Distance(currentPosition, player.transform.position);
            if (distanceToPlayer < closestDistance)
            {
                closestDistance = distanceToPlayer;
                closestPlayer = player;
            }
        }

        return closestPlayer;
    }

}

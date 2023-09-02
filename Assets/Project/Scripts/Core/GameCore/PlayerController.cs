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
    
    public void FindAndAddPlayers()
    {
        playerUnits.Clear();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 0)
        {
            foreach (GameObject player in players)
            {
                UnitController unitController = player.transform.parent.GetComponent<UnitController>();
                playerUnits.Add(player);

                if (FindClosestEnemy(player) != null)
                {
                    unitController.TargetPos = FindClosestEnemy(player).transform;
                }
            }
        }
        else
        {
            Debug.Log("Lose");
        }
    }
    
    public GameObject FindClosestEnemy(GameObject player)
    {
        string nameUnit = player.name.Substring(5, 5);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = Vector2.zero;
        if (enemies.Length > 0)
        {
            if (nameUnit == "Melee")
            {
                currentPosition = player.transform.parent.GetComponent<UnitMeleeController>().UnitMeleeModel.transform.position;
            }

            if (nameUnit == "Range")
            {
                currentPosition = player.transform.parent.GetComponent<UnitRangeController>().UnitRangeModel.transform.position;
            }
        
        
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(currentPosition, enemy.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }
            }
        }
        
        return closestEnemy;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitRangeController : UnitController
{
    [SerializeField] private UnitRangeAttack unitRangeAttack;
    public UnitRangeAttack UnitRangeAttack
    {
        get => unitRangeAttack;
    }
    
    [SerializeField] private UnitModel unitModel;
    public UnitModel UnitModel
    {
        get => unitModel;
    }
    
    private void Start()
    {
        tagetPos = DetectTargetPos();
    }

    private Transform DetectTargetPos()
    {
        Transform nearestObject = null;
        float closestDistance = Mathf.Infinity;
        
        if (unitModel.gameObject.CompareTag("Player"))
        {
            foreach (GameObject enemy in EnemyController.Instance.EnemyUnits)
            {
                float distance = Vector3.Distance( unitModel.transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestObject = enemy.transform;
                }
            }
            
            return nearestObject;
        }
        else if(unitModel.gameObject.CompareTag("Enemy"))
        {
            foreach (GameObject player in PlayerController.Instance.PlayerUnits)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestObject = player.transform;
                }
            }
            
            return nearestObject;
        }

        return null;
    }
}

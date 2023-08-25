using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitMeleeController : UnitController
{
    [SerializeField] private UnitMeleeAttack unitMeleeAttack;
    public UnitMeleeAttack UnitMeleeAttack
    {
        get => unitMeleeAttack;
    }
    
    [SerializeField] private UnitMeleeMovement unitMeleeMovement;
    public UnitMeleeAttack UnitMeleeMovement
    {
        get => unitMeleeAttack;
    }
    
    [SerializeField] private UnitMeleeModel unitMeleeModel;
    public UnitMeleeModel UnitMeleeModel
    {
        get => unitMeleeModel;
    }
    
    private void Start()
    {
        DetectTargetPos();
    }

    private void DetectTargetPos()
    {
        Transform nearestObject = null;
        float closestDistance = Mathf.Infinity;
    
        Transform unitTransform = unitMeleeModel.transform;
        List<Transform> targetTransforms = unitMeleeModel.gameObject.CompareTag("Player") ?
            EnemyController.Instance.EnemyUnits.ConvertAll(enemy => enemy.transform) :
            PlayerController.Instance.PlayerUnits.ConvertAll(player => player.transform);

        foreach (Transform targetTransform in targetTransforms)
        {
            float distance = Vector3.Distance(unitTransform.position, targetTransform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestObject = targetTransform;
            }
        }

        tagetPos = nearestObject;
    }
}

using System;
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

    private void Update()
    {
        CheckRotateModel();
    }

    private void DetectTargetPos()
    {
        Transform nearestObject = null;
        float closestDistance = Mathf.Infinity;
    
        List<Transform> targetTransforms = unitMeleeModel.gameObject.CompareTag("Player") ?
            EnemyController.Instance.EnemyUnits.ConvertAll(enemy => enemy.transform) :
            PlayerController.Instance.PlayerUnits.ConvertAll(player => player.transform);

        foreach (Transform targetTransform in targetTransforms)
        {
            float distance = Vector3.Distance(unitMeleeModel.transform.position, targetTransform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestObject = targetTransform;
            }
        }

        targetPos = nearestObject;
    }
    
    private void CheckRotateModel()
    {
        if (targetPos != null)
        {
            float direction = Mathf.Sign(targetPos.position.x - unitMeleeModel.transform.position.x);
            string side = direction > 0 ? "right" : "left";
    
            if (side == "left")
            {
                unitMeleeModel.transform.localScale = new Vector3(-Mathf.Abs(unitMeleeModel.transform.localScale.x), unitMeleeModel.transform.localScale.y, unitMeleeModel.transform.localScale.z);
            }
            else
            {
                unitMeleeModel.transform.localScale = new Vector3(Mathf.Abs(unitMeleeModel.transform.localScale.x), unitMeleeModel.transform.localScale.y, unitMeleeModel.transform.localScale.z);
            }
        }
    }
}

using System;
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
    
    [SerializeField] private UnitRangeModel unitRangeModel;
    public UnitModel UnitModel
    {
        get => unitRangeModel;
    }
    
    private UnitStateMachine stateMachine;
    public UnitStateMachine StateMachine
    {
        get => stateMachine;
    }
    
    private void Start()
    {
        DetectTargetPos();
                
        stateMachine = new UnitStateMachine();
        stateMachine.ChangeState(new UnitRangeIdleState(this));
    }
    
    private void Update()
    {
        CheckRotateModel();
        stateMachine.UpdateCurrentState();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdateCurrentState();
    }

    public void DetectTargetPos()
    {
        Transform nearestObject = null;
        float closestDistance = Mathf.Infinity;
    
        List<Transform> targetTransforms = unitRangeModel.gameObject.CompareTag("Player") ?
            EnemyController.Instance.EnemyUnits.ConvertAll(enemy => enemy.transform) :
            PlayerController.Instance.PlayerUnits.ConvertAll(player => player.transform);

        foreach (Transform targetTransform in targetTransforms)
        {
            float distance = Vector3.Distance(unitRangeModel.transform.position, targetTransform.position);
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
        if (targetPos != null && GameController.Instance.IsStartBattle)
        {
            float direction = Mathf.Sign(targetPos.position.x - unitRangeModel.transform.position.x);
            string side = direction > 0 ? "right" : "left";
    
            if (side == "left")
            {
                unitRangeModel.transform.localScale = new Vector3(-Mathf.Abs(unitRangeModel.transform.localScale.x), unitRangeModel.transform.localScale.y, unitRangeModel.transform.localScale.z);
            }
            else
            {
                unitRangeModel.transform.localScale = new Vector3(Mathf.Abs(unitRangeModel.transform.localScale.x), unitRangeModel.transform.localScale.y, unitRangeModel.transform.localScale.z);
            }
        }
    }
}

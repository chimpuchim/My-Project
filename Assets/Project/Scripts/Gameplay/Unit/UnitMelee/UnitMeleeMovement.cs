using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitMeleeMovement : UnitMovement
{
    [SerializeField] private UnitMeleeController unitMeleeController;
    [SerializeField] private float distanceAttack;
    

    public override void Movement(Vector3 targetPos)
    {
        if (GameController.Instance.IsStartBattle)
        {
            float distance = Vector3.Distance(unitMeleeController.UnitMeleeModel.transform.position, targetPos);

            if (distance > distanceAttack)
            {
                unitMeleeController.UnitMeleeModel.Agent.enabled = true;
                unitMeleeController.UnitMeleeModel.Agent.SetDestination(targetPos);
            }
            else
            {
                unitMeleeController.UnitMeleeModel.Agent.enabled = false;
            }
        }
    }

    private void Update()
    {
        Movement(unitMeleeController.TargetPos.position);
    }
}

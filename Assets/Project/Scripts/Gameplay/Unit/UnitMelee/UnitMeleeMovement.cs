using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMeleeMovement : UnitMovement
{
    [SerializeField] private UnitMeleeController unitController;

    public override void Movement(Vector3 tagetPos)
    {
        unitController.UnitMeleeModel.Agent.speed = speed;
        unitController.UnitMeleeModel.Agent.SetDestination(tagetPos);
    }

    private void Update()
    {
        Movement(unitController.TargetPos.position);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMeleeMovement : UnitMovement
{
    [SerializeField] private UnitMeleeController unitMeleeController;

    
    public override void Movement(Vector3 targetPos)
    {
        unitMeleeController.UnitMeleeModel.Agent.SetDestination(targetPos);
    }
}

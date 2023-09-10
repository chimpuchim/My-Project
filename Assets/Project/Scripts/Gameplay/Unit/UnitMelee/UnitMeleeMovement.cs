using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMeleeMovement : UnitMovement
{
    [SerializeField] private UnitMeleeController unitMeleeController;


    private void Update()
    {
        if (unitMeleeController.IsDead && PlayerController.Instance.PlayerUnits.Count <= 0 || EnemyController.Instance.EnemyUnits.Count <= 0)
        {
            unitMeleeController.UnitMeleeModel.Agent.speed = 0;
        }
    }

    public override void Movement(Vector3 targetPos)
    {
        unitMeleeController.UnitMeleeModel.Agent.SetDestination(targetPos);
    }
}

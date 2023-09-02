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
    public UnitRangeModel UnitRangeModel
    {
        get => unitRangeModel;
    }
    
    private UnitStateMachine stateMachine;
    public UnitStateMachine StateMachine
    {
        get => stateMachine;
    }

    
    protected override void Start()
    {
        base.Start();
        stateMachine = new UnitStateMachine();
        stateMachine.ChangeState(new UnitRangeIdleState(this));
    }
    
    private void Update()
    {
        CheckRotateModel(unitRangeModel.transform);
        stateMachine.UpdateCurrentState();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdateCurrentState();
    }
}

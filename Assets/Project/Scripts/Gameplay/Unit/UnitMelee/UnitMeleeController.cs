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
    public UnitMeleeMovement UnitMeleeMovement
    {
        get => unitMeleeMovement;
    }
    
    [SerializeField] private UnitMeleeModel unitMeleeModel;
    public UnitMeleeModel UnitMeleeModel
    {
        get => unitMeleeModel;
    }
    
    private UnitStateMachine stateMachine;
    public UnitStateMachine StateMachine
    {
        get => stateMachine;
    }

    private UnitMeleeUIHealthBar unitMeleeUIHealthBar;
    public UnitMeleeUIHealthBar UnitMeleeUIHealthBar
    {
        get => unitMeleeUIHealthBar;
    }
    
    [SerializeField] private float distanceToTarget;
    public float DistanceToTarget
    {
        get => distanceToTarget;
    }
    
    [SerializeField] private float distanceAttack;
    public float DistanceAttack
    {
        get => distanceAttack;
    }
    
    
    private void Start()
    {
        stateMachine = new UnitStateMachine();
        stateMachine.ChangeState(new UnitMeleeIdleState(this));
    }

    private void Update()
    {
        distanceToTarget = Vector2.Distance(unitMeleeModel.transform.position, targetPos.position);
        CheckRotateModel(unitMeleeModel.transform);
        stateMachine.UpdateCurrentState();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdateCurrentState();
    }

    
}

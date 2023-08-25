using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMeleeModel : UnitModel
{
    [SerializeField] private UnitMeleeController unitController;
    
    [SerializeField] private NavMeshAgent agent;
    public NavMeshAgent Agent
    {
        get => agent;
    }


    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
}

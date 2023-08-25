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
}

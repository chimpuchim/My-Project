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
}

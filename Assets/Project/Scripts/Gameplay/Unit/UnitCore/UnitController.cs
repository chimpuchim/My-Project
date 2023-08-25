using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] protected Transform tagetPos;
    public Transform TargetPos
    {
        get => tagetPos;
    }
    
    [Header("Setup")]
    [SerializeField] private UnitStats unitStats;
    public UnitStats UnitStats
    {
        get => unitStats;
    }
    
    [SerializeField] private UnitDamageAble unitDamageAble;
    public UnitDamageAble UnitDamageAble
    {
        get => unitDamageAble;
    }
}

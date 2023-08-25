using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitController : MonoBehaviour
{
    [SerializeField] protected Transform targetPos;
    public Transform TargetPos
    {
        get => targetPos;
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

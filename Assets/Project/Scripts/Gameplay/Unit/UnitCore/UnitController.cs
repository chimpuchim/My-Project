using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitController : MonoBehaviour
{
    [SerializeField] private bool isDead;
    public bool IsDead
    {
        get => isDead;
        set => isDead = value;
    }
    
    [SerializeField] protected Transform targetPos;
    public Transform TargetPos
    {
        get => targetPos;
        set => targetPos = value;
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

    [SerializeField] private UnitMoney unitMoney;
    public UnitMoney UnitMoney
    {
        get => unitMoney;
    }
    

    protected virtual void Start()
    {
    }

    protected void CheckRotateModel(Transform unitModel)
    {
        if (targetPos != null && GameController.Instance.IsStartBattle)
        {
            float direction = Mathf.Sign(targetPos.position.x - unitModel.position.x);
            string side = direction > 0 ? "right" : "left";
    
            if (side == "left")
            {
                unitModel.localScale = new Vector3(-Mathf.Abs(unitModel.localScale.x), unitModel.localScale.y, unitModel.localScale.z);
            }
            else
            {
                unitModel.localScale = new Vector3(Mathf.Abs(unitModel.localScale.x), unitModel.localScale.y, unitModel.localScale.z);
            }
        }
    }
}

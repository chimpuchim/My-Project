using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoney : MonoBehaviour
{
    [SerializeField] private UnitController unitController;

    [SerializeField] private int money;
    public int Money
    {
        get => money;
    }
}

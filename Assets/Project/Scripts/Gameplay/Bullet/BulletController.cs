using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public BulletModel BulletModel;
    public BulletStat BulletStat;

    [SerializeField] private bool isEnemy;
    public bool IsEnemy
    {
        get => isEnemy;
        set => isEnemy = value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDamageAble : MonoBehaviour, IRecieveDamage, ISendDamege
{
    [SerializeField] private UnitController unitController;
    [SerializeField] private float damage;
    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    public void RecieveDamage(float damageRecieve)
    {
        unitController.UnitStats.Heal(-damageRecieve);
    }


    public void SendDamege(IRecieveDamage client)
    {
        client.RecieveDamage(damage);
    }
}

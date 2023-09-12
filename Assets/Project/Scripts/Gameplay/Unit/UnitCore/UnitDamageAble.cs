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

    public void ReceiveDamage(float damageRecieve)
    {
        unitController.UnitStats.Heal(-damageRecieve);

        if (unitController.UnitStats.CurrentHealth <= 0)
        {
            unitController.IsDead = true;
        }
    }


    public void SendDamage(IRecieveDamage client)
    {
        client.ReceiveDamage(damage);
    }
}

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

    public void RecieveDamage(int damageRecieve)
    {
        unitController.UnitStats.Heal(-damageRecieve);
    }


    public void SendDamege(int damageSend, IRecieveDamage client)
    {
        client.RecieveDamage(damageSend);
    }
}

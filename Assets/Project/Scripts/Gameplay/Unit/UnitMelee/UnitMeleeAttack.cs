using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitMeleeAttack : UnitAttack
{
    [SerializeField] private UnitMeleeController unitMeleeController;

    public override void AttackNor()
    {
        unitMeleeController.UnitDamageAble.SendDamage(unitMeleeController.TargetPos.parent.gameObject.GetComponent<UnitController>().UnitDamageAble);
        unitMeleeController.UnitMeleeModel.FightFx.GetComponent<ParticleSystem>().Play();
    }
}

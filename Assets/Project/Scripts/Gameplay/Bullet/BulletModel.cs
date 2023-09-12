using System;
using UnityEngine;

public class BulletModel : MonoBehaviour
{
    [SerializeField] private BulletController bulletController;
    [SerializeField] private Rigidbody2D rigidbody2D;
    public Rigidbody2D Rigidbody2D
    {
        get => rigidbody2D;
    }

    private string unitType;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (bulletController.IsEnemy)
        {
            unitType = "Player";
        }
        else
        {
            unitType = "Enemy";
        }

        
        if (other.transform.parent.GetComponent<UnitController>() != null && other.CompareTag(unitType))
        {
            UnitController unitController = other.transform.parent.gameObject.GetComponent<UnitController>();
            unitController.UnitDamageAble.ReceiveDamage(bulletController.BulletStat.Damage);
            
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class UnitRangeAttack : UnitAttack
{
    [SerializeField] private UnitRangeController unitRangeController;
    [SerializeField] private GameObject[] bulletPrefab;
    public GameObject BulletPrefab
    {
        get => BulletPrefab;
    }

    public override void AttackNor()
    {
        if (unitRangeController.TargetPos != null)
        {
            Vector3 directionToEnemy = unitRangeController.TargetPos.position - unitRangeController.UnitRangeModel.transform.position;
            Vector3 normalizedDirection = directionToEnemy.normalized;
            
            string numberUnit = Regex.Match(unitRangeController.UnitRangeModel.name, @"\d+").Value;
            
            GameObject bullet = Instantiate(bulletPrefab[int.Parse(numberUnit) - 1], transform.position, Quaternion.identity);
            BulletController bulletController = bullet.GetComponent<BulletController>();
            Rigidbody2D bulletRigidbody = bulletController.BulletModel.Rigidbody2D;
            
            if (unitRangeController.UnitRangeModel.CompareTag("Enemy"))
            {
                bulletController.IsEnemy = true;
            }

            bulletRigidbody.velocity = normalizedDirection * bullet.GetComponent<BulletController>().BulletStat.Speed;

            Destroy(bullet, 5f);
        }
    }
            
}

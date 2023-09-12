using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStat : MonoBehaviour
{
   [SerializeField] private float speed;
   public float Speed
   {
      get => speed;
   }
   
   [SerializeField] private float damage;
   public float Damage
   {
      get => damage;
      set => damage = value;
   }
}

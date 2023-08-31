using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    public Rigidbody2D Rigidbody2D
    {
        get => rigidbody2D;
    }
    
    // void OnTriggerEnter2D(IRecieveDamage client)
    // {
    //     
    // }
}

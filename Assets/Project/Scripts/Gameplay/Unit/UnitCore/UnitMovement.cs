using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private float speed;
    public float Speed
    {
        get => speed;
        set => speed = value;
    }
    

    public virtual void Movement()
    {
        
    }
}

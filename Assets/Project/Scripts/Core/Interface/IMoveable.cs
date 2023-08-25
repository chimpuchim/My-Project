using UnityEngine;

public interface IMoveable
{
    float Speed { get; }
    
    public void Movement(Vector3 tagerPos);
}

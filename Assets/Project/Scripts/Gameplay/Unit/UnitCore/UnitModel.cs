using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitModel : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void ChangeAnimation(string state, float speed)
    {
        if (!animator.IsInTransition(0))
        {
            animator.CrossFade(state, speed);
        }
    }
}

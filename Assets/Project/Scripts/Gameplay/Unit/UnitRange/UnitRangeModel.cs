using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRangeModel : UnitModel
{
    public void ChangeAnimation(string state, float speed)
    {
        if (!animator.IsInTransition(0))
        {
            animator.CrossFade(state, speed);
        }
    }
}

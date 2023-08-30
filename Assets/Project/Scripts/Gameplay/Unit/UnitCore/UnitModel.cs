using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitModel : MonoBehaviour
{
    [SerializeField] protected Animator animator;
        
    [SerializeField] private Slider sliderHealthBar;
    public Slider SliderHealthBar
    {
        get => sliderHealthBar;
    }
    
        
    public void ChangeAnimation(string state, float speed)
    {
        if (!animator.IsInTransition(0))
        {
            animator.CrossFade(state, speed);
        }
    }
}

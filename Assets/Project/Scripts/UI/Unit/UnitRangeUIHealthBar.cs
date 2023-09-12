using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitRangeUIHealthBar : MonoBehaviour
{
    [SerializeField] private UnitRangeController unitRangeController;


    private void Awake()
    {
        unitRangeController.UnitStats.HealthChanged += UpdateHealthSlider;
        
        unitRangeController.UnitRangeModel.SliderHealthBar.maxValue = unitRangeController.UnitStats.MaxHealth;
        UpdateHealthSlider(unitRangeController.UnitStats.MaxHealth, unitRangeController.UnitStats.CurrentHealth);
    }
    
    private void UpdateHealthSlider(float maxHealth, float currentHealth)
    {
        unitRangeController.UnitRangeModel.SliderHealthBar.value = currentHealth;
    }
}

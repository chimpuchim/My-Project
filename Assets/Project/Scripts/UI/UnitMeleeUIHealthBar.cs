using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitMeleeUIHealthBar : MonoBehaviour
{
    [SerializeField] private UnitMeleeController unitMeleeController;
    [SerializeField] private TextMeshProUGUI dameSendText;


    private void Awake()
    {
        unitMeleeController.UnitStats.HealthChanged += UpdateHealthSlider;
        
        unitMeleeController.UnitMeleeModel.SliderHealthBar.maxValue = unitMeleeController.UnitStats.MaxHealth;
        UpdateHealthSlider(unitMeleeController.UnitStats.MaxHealth, unitMeleeController.UnitStats.CurrentHealth);
    }
    
    private void UpdateHealthSlider(float maxHealth, float currentHealth)
    {
        unitMeleeController.UnitMeleeModel.SliderHealthBar.value = currentHealth;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class UnitMeleeUIHealthBar : MonoBehaviour
{
    [SerializeField] private UnitMeleeController unitMeleeController;
    [SerializeField] private TextMeshProUGUI dameSendText;

    private Vector2 curPosDameSendText;


    private void Awake()
    {
        unitMeleeController.UnitStats.HealthChanged += UpdateHealthSlider;
        
        unitMeleeController.UnitMeleeModel.SliderHealthBar.maxValue = unitMeleeController.UnitStats.MaxHealth;
        UpdateHealthSlider(unitMeleeController.UnitStats.MaxHealth, unitMeleeController.UnitStats.CurrentHealth);
    }

    private void Start()
    {
        curPosDameSendText = dameSendText.transform.localPosition;
    }

    private void Update()
    {
        if (unitMeleeController.UnitMeleeModel.transform.localScale.x < 0)
        {
            dameSendText.transform.localScale = new Vector2(-Mathf.Abs(dameSendText.transform.localScale.x), dameSendText.transform.localScale.y);
            return;
        }
        
        dameSendText.transform.localScale = new Vector2(Mathf.Abs(dameSendText.transform.localScale.x), dameSendText.transform.localScale.y);
    }

    private void UpdateHealthSlider(float maxHealth, float currentHealth)
    {
        unitMeleeController.UnitMeleeModel.SliderHealthBar.value = currentHealth;
    }

    public void ShowDameSendText()
    {
        dameSendText.enabled = true;
        dameSendText.text = "-" + unitMeleeController.UnitDamageAble.Damage;
        dameSendText.transform.DOMoveY(dameSendText.transform.position.y + 0.2f,1f).OnComplete(() =>
        {
            dameSendText.transform.localPosition = curPosDameSendText;
            dameSendText.enabled = false;
        });
    }
}

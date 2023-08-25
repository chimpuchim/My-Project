using System;
using UnityEngine;

public class UnitStats : MonoBehaviour, IStat
{
    [SerializeField] private UnitController unitController;
    [SerializeField] private float maxHealth;
    public float MaxHealth
    {
        get => maxHealth;
    }
    [SerializeField] private float currentHealth;
    public float CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    public event Action<float, float> HealthChanged;
    

    private void Start()
    {
        currentHealth = maxHealth;
        HealthChanged?.Invoke(maxHealth, currentHealth);
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    
        HealthChanged?.Invoke(maxHealth, currentHealth);
    }
}

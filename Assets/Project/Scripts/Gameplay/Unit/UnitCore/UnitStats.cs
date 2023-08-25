using System;
using UnityEngine;

public class UnitStats : MonoBehaviour, IStat
{
    [SerializeField] private UnitController unitController;
    [SerializeField] private int maxHealth;
    public int MaxHealth
    {
        get => maxHealth;
    }
    [SerializeField] private int currentHealth;
    public int CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    public event Action<int, int> HealthChanged;
    

    private void Start()
    {
        currentHealth = maxHealth;
        HealthChanged?.Invoke(maxHealth, currentHealth);
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    
        HealthChanged?.Invoke(maxHealth, currentHealth);
    }
}

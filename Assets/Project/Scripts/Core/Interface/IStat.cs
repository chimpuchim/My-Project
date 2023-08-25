using System;

public interface IStat
{
    int MaxHealth { get; }
    int CurrentHealth { get; }

    event Action<int, int> HealthChanged;
    
    void Heal(int healAmount);
}

using System;

public interface IStat
{
    float MaxHealth { get; }
    float CurrentHealth { get; }

    event Action<float, float> HealthChanged;
    
    void Heal(float healAmount);
}

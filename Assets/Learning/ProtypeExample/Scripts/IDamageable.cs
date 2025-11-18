using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damageAmount);
    float CurrentHealth { get; }
    float HealthPercent { get; }
}

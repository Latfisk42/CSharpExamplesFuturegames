using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public event Action OnDeath;
    public event Action<float> OnHealthChanged;

    public float CurrentHealth => currentHealth;
    public float HealthPercent => currentHealth / maxHealth;
    public float currentHealth;

    private float maxHealth = 100f;


    private void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage) {
        if(GameData.godMode || GameData.playerIsDead) {
            return;
        }
        currentHealth = Mathf.Max(0, currentHealth - damage);
        OnHealthChanged?.Invoke(HealthPercent);

        if(currentHealth <= 0) {
            OnDeath?.Invoke();
        }
    }



}

using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public event Action<int> OnDeath;
    public event Action<float> OnHealthChanged;
    public event Action OnGameOver;

    public float CurrentHealth => currentHealth;
    public float HealthPercent => currentHealth / maxHealth;
    public float currentHealth;

    private float maxHealth = 100f;
    private static int lives = 3;

    private void Start() {
        currentHealth = maxHealth;
        lives = GameData.playerLives;
    }

    public void TakeDamage(float damage) {
        if(GameData.godMode || GameData.playerIsDead) {
            return;
        }
        currentHealth = Mathf.Max(0, currentHealth - damage);
        OnHealthChanged?.Invoke(HealthPercent);

        if(currentHealth <= 0) {
            Kill();
        }
    }
    private void Kill() {
        lives--;
        OnDeath?.Invoke(lives);
        GameData.playerIsDead = true;
        Debug.Log($"Player died. Lives remaining: {lives}");
        if(lives <= 0) {
            OnGameOver?.Invoke();
        }
        else {
            Invoke("RespawnPlayer", 2f);
        }
    }
    private void RespawnPlayer() {
        currentHealth = 100;
        GameData.playerIsDead = false;
        OnHealthChanged?.Invoke(HealthPercent);
    }



}

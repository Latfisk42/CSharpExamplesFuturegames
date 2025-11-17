using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int maxPlayerHealth = 100;
    public static event Action<int, int> OnPlayerHealthChanged; // (current, max)
    public static event Action OnPlayerDied;

    public static float PlayerHealth
    {
        get => GameData.playerHealth;
        set
        {
            int newHealth = Mathf.Clamp(Mathf.RoundToInt(value), 0, maxPlayerHealth);
            float previousHealth = GameData.playerHealth;
            if (previousHealth == newHealth) return;

            GameData.playerHealth = newHealth;
            OnPlayerHealthChanged?.Invoke(newHealth, maxPlayerHealth);

            if (newHealth <= 0)
            {
                // Ensure death event called once
                OnPlayerDied?.Invoke();
            }
        }
    }
}

using Learning.Prototype;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Image healthBar;

    public static bool godMode = false;
    public record PlayerInfo(string Name, int Level, float Health, int HighScore);

    private static int lives = 3;
    private static int level = 1;
    private PlayerInfo playerRecord;
    private PlayerHealth playerHealth;



    private void Awake() {
        lives = GameData.playerLives;
        level = GameData.currentLevel;
        playerHealth = GetComponent<PlayerHealth>();
        float health = playerHealth.HealthPercent;
        playerHealth.OnHealthChanged += UpdateHealthbar;
        playerHealth.OnDeath += Kill;


        playerRecord = new PlayerInfo("Player", level, health, PlayerPrefs.GetInt("HighScore", 0));
        Debug.Log("Starting Player Info: " + playerRecord);
    }


    public void UpdateHealthbar(float healthPercent) {

        healthBar.fillAmount = healthPercent;
    }

    private void Kill() {
        lives--;
        GameData.playerIsDead = true;
        Debug.Log($"Player died. Lives remaining: {lives}");
        if(lives <= 0) {
            GameOver();
        }
        else {
            Invoke("RespawnPlayer", 2f);
        }
    }

    private void RespawnPlayer() {
        playerHealth.currentHealth = 100;
        GameData.playerIsDead = false;
        UpdateHealthbar(1f);
    }

    private void GameOver() {
        GameData.gameIsOver = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
    private void OnDestroy() {
        playerHealth.OnHealthChanged -= UpdateHealthbar;
        playerHealth.OnDeath -= Kill;
    }

}

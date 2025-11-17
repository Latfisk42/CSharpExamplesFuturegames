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




    private void Awake() {
        lives = GameData.playerLives;
        level = GameData.currentLevel;

        playerRecord = new PlayerInfo("Player", level, GameData.playerHealth, UiManager.highScore);
        Debug.Log("Starting Player Info: " + playerRecord);
    }

    private void Update() {
        Debug.Log(PlayerHealth);
    }

    public static float PlayerHealth {
        get => GameData.playerHealth;
        set => GameData.playerHealth = (int)value;
    }


    public void DamagePlayer(float dmg) {
        if(godMode) {
            return;

        }
        PlayerHealth -= dmg;
        healthBar.fillAmount -= GetDamagePercent(dmg);
        if(GameData.playerHealth <= 0) {
            KillPlayer();
        }
    }
    private float GetDamagePercent(float dmg) {
        return dmg / 1f;
    }

    private void KillPlayer() {
        GameData.playerIsDead = true;
        lives--;
        if(lives <= 0) {
           GameOver();
        }
        else {
            Invoke("RespawnPlayer", 2f);
        }
    }

    private void RespawnPlayer() {
        healthBar.fillAmount = 1f;
        GameData.playerHealth = 100;
        GameData.playerIsDead = false;
        //RefreshUI();
    }

    private void GameOver() {
        GameData.gameIsOver = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

}

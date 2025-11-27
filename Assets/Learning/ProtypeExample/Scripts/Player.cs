using Learning.Prototype;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public record PlayerInfo(string Name, int Level, float Health, int HighScore);

    private static int level = 1;
    private PlayerInfo playerRecord;
    private PlayerHealth playerHealth;

    private void Awake() {
        level = GameData.currentLevel;
        float health = playerHealth.currentHealth;

        playerRecord = new PlayerInfo("Player", level, health, PlayerPrefs.GetInt("HighScore", 0));
        Debug.Log("Starting Player Info: " + playerRecord);
    }
    private void GameOver() {
        GameData.gameIsOver = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

}

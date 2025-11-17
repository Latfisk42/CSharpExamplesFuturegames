using System;
using TMPro;
using UnityEngine;

namespace Learning.Prototype {
    public sealed class UiManager : MonoBehaviour{
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI livesText;
        public TextMeshProUGUI weaponText;
        public TextMeshProUGUI ammoText;
        public TextMeshProUGUI highScoreText;

        public static int score = 0;
        public static int highScore = 0;

        private static int lives = 3;
        private void Awake() {
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            lives = PlayerPrefs.GetInt("Lives", 3);

            RefreshUI();
        }
        private void Update() {
            if(score >= 5000 && !GameData.gameIsOver) {
                Victory();

            }
        }

        private void RefreshUI() {
            //Should I refresh?
            scoreText.text = score.ToString();
            livesText.text = lives.ToString();
            //weaponText.text = GameManager.currentWeapon.ToString();
            //ammoText.text = GameManager.ammoDict[GameManager.currentWeapon].ToString();
            highScoreText.text = highScore.ToString();
        }

        public void AddScore(int s) {
            score += s;
            if(score > highScore) {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            //RefreshUI();
        }
        private void Victory() {
            GameData.gameIsOver = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }

    }
}

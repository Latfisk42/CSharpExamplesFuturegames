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

        private int score;
        private int _currentLives;
        private string currentWeapon;
        private int ammo;
        private int highScore;

       public WeaponSystem weaponSystem;

        private static int lives = 3;
        private void Awake() {
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            lives = PlayerPrefs.GetInt("Lives", 3);

            weaponSystem.OnWeaponChanged += UpdateWeaponUI;
            weaponSystem.OnAmmoChanged += UpdateAmmoUI;

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
            weaponText.text = currentWeapon;
            ammoText.text = ammo.ToString();
            highScoreText.text = highScore.ToString();
        }
        private void UpdateWeaponUI(int weaponIndex) {
            currentWeapon = ((WeaponSystem.Weapons)weaponIndex).ToString();
            RefreshUI();
        }
        private void UpdateAmmoUI(int newAmmo) {
            ammo = newAmmo;
            RefreshUI();
        }

        public void AddScore(int s) {
            score += s;
            if(score > highScore) {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            if(score >= 500) {
                Victory();
            }

            RefreshUI();
        }
        private void Victory() {
            GameData.gameIsOver = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }

    }
}

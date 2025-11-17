using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using Random = UnityEngine.Random;

namespace Learning.Prototype {
    //weapon system
    internal enum Weapons {
        None,
        Pistol,
        Rifle,
        RocketLauncher
    }

    public record PlayerInfo(string Name, int Level, float Health, int HighScore);

    public sealed class GameManager : MonoBehaviour {

        public static bool godMode = false;
        //UI Data
        public static int score = 0;
        public static int highScore = 0;
        //move to input manager later
        public static float mouseSensitivity = 2f;
        private static Weapons currentWeapon = Weapons.Pistol;

        public static GameManager Instance;
        //Weapon system
        private static readonly Dictionary<Weapons, int> ammoDict = new() {
            { Weapons.None, 0 },
            { Weapons.Pistol, 99 },
            { Weapons.Rifle, 0 },
            { Weapons.RocketLauncher, 0 }
        };




        //camera
        public CameraControl cameraControl;
        //player need to know about game manager
        public Player player;
        //Spawner manager
        public Enemy enemyPrefab;
        public Transform[] spawnPoints;
        private float nextSpawn = 0;

        public GameObject bulletPrefab;
        //UI Elements
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI livesText;
        public TextMeshProUGUI weaponText;
        public TextMeshProUGUI ammoText;
        public TextMeshProUGUI highScoreText;


        private static int lives = 3;
        private static int level = 1;

        private Queue<Bullet> activeBullets;
        private PlayerInfo playerRecord;

        public static float PlayerHealth {
            get => GameData.playerHealth;
            set => GameData.playerHealth = (int)value;
        }

        private void Awake() {
            if(Instance != null && Instance != this) {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            lives = GameData.playerLives;
            level = GameData.currentLevel;
            playerRecord = new PlayerInfo("Player", level, GameData.playerHealth, highScore);
            Debug.Log("Starting Player Info: " + playerRecord);
        }


        #region InputManagement

        private void InputHandler()
        {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                if(GameData.gameIsPaused) {
                    UnPause();
                }
                else {
                    Pause();
                }
            }

            if(Input.GetKeyDown(KeyCode.Alpha1)) {
                godMode = !godMode;
                Debug.Log("GodMode " + godMode);
            }

            if(Input.GetKeyDown(KeyCode.Alpha2)) {
                score += 1000;
                //Remove and make a refresh
                RefreshUI();
            }

            if(Input.GetKeyDown(KeyCode.E)) {
                PlayerShoot();
            }

            if(!GameData.gameIsPaused && !GameData.playerIsDead) {
                float mx = Input.GetAxis("Mouse X") * mouseSensitivity;
                float my = Input.GetAxis("Mouse Y") * mouseSensitivity;
            }
        }

        #endregion

        private void Start() {
            RefreshUI();
        }

        private void Update() {
            InputHandler();

            if(GameData.showFPS && Time.frameCount % 10 == 0) {
                //Debug.Log("FPS: " + (1f / Time.deltaTime).ToString("F1"));
            }

            EnemySpawner();

            if(score >= 5000 && !GameData.gameIsOver) {
                Victory();
            }
        }
        #region EnemySpawner
        private void EnemySpawner()
        {
            if(!GameData.gameIsOver && !GameData.gameIsPaused && Time.time > nextSpawn) {
                nextSpawn = Time.time + Random.Range(1f, 3f);
                int r = Random.Range(0, spawnPoints.Length);
                Enemy enemy = Instantiate(enemyPrefab, spawnPoints[r].position, Quaternion.identity);
                enemy.transform.position = new Vector3(enemy.transform.position.x + Random.Range(1f, 3f), enemy.transform.position.y, enemy.transform.position.z + Random.Range(1f, 3f));
                enemy.transform.LookAt(player.transform);
                StartMovingTowardsPlayer(enemy);
            }
        }

        private void StartMovingTowardsPlayer(Enemy enemy) {
            enemy.StartMovingTowards(player.transform);
        }
        #endregion

        private void RefreshUI() {
            //Should I refresh?
            scoreText.text = score.ToString();
            livesText.text = lives.ToString();
            weaponText.text = currentWeapon.ToString();
            ammoText.text = ammoDict[currentWeapon].ToString();
            highScoreText.text = highScore.ToString();
        }

        public void Pause() {
            GameData.gameIsPaused = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }

        public void UnPause() {
            GameData.gameIsPaused = false;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }


        public void PlayerShoot() {
            if(ammoDict[currentWeapon] <= 0) {
                return;
            }
            ammoDict[currentWeapon]--;
            RefreshUI();
            var go = Instantiate(bulletPrefab, player.transform.position + player.transform.forward, player.transform.rotation);
            var bullet = go.GetComponent<Bullet>();
            activeBullets.Enqueue(bullet);
            MoveBullet();
        }
        private void MoveBullet() {
            throw new System.NotImplementedException();
        }

        public void DamagePlayer(float dmg) {
            if(godMode) {
                return;

            }
            PlayerHealth -= dmg;
            player.healthBar.fillAmount -= GetDamagePercent(dmg);
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
            player.healthBar.fillAmount = 1f;
            GameData.playerHealth = 100;
            GameData.playerIsDead = false;
            RefreshUI();
        }

        public void AddScore(int s) {
            score += s;
            if(score > highScore) {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            RefreshUI();
        }

        private void GameOver() {
            GameData.gameIsOver = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }

        private void Victory() {
            GameData.gameIsOver = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }

        public void QuitGame() {
            Application.Quit();
        }
    }

}

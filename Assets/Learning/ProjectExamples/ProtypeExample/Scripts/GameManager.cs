using UnityEngine;


namespace Learning.Prototype {

    public sealed class GameManager : MonoBehaviour {

        public static GameManager Instance;

<<<<<<< HEAD:Assets/Learning/ProtypeExample/Scripts/GameManager.cs
=======
        internal static readonly Dictionary<Weapons, int> ammoDict = new() {
            { Weapons.None, 0 },
            { Weapons.Pistol, 99 },
            { Weapons.Rifle, 0 },
            { Weapons.RocketLauncher, 0 }
        };
        
        public Player player;
        public Enemy enemyPrefab;
        public GameObject bulletPrefab;

        public GameObject explosionPrefab;

        // public AudioClip jumpSound;
        // public AudioClip shootSound;
        // public AudioClip dieSound;
        public AudioSource musicSource;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI livesText;
        public TextMeshProUGUI weaponText;
        public TextMeshProUGUI ammoText;
        public TextMeshProUGUI highScoreText;
        public Slider volumeSlider;
        public GameObject pausePanel;
        public GameObject gameOverPanel;
        public GameObject victoryPanel;
        public Transform[] spawnPoints;
        public List<Enemy> enemies; //DO NOT ASSIGN THIS IN INSPECTOR, USED FOR TRACKING ENEMIES

        private static int lives = 3;
        private static int level = 1;
        private float nextSpawn = 0;
        private Queue<Bullet> activeBullets;
        private PlayerInfo playerRecord;

        public static float PlayerHealth {
            get => GameData.playerHealth;
            set => GameData.playerHealth = (int)value;
        }

>>>>>>> upstream/main:Assets/Learning/ProjectExamples/ProtypeExample/Scripts/GameManager.cs
        private void Awake() {
            if(Instance != null && Instance != this) {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Update() {
           // if(score >= 5000 && !GameData.gameIsOver) {
           //    Victory();
           // }

            if(GameData.showFPS && Time.frameCount % 10 == 0) {
                //Debug.Log("FPS: " + (1f / Time.deltaTime).ToString("F1"));
            }
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

using UnityEngine;


namespace Learning.Prototype {

    public sealed class GameManager : MonoBehaviour {

        public static GameManager Instance;

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

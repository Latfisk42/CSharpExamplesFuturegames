using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Learning.Prototype {
    public class InputManager : MonoBehaviour {

        public int i;
        public static float mouseSensitivity = 2f;
        public WeaponSystem weaponSystem;

        private void Update() {
            InputHandler();
        }

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
                GameData.godMode = !GameData.godMode;
                Debug.Log("GodMode " + GameData.godMode);
            }

            if(Input.GetKeyDown(KeyCode.Alpha2)) {
                //score += 1000;
                //Remove and make a refresh
                //UIManager.RefreshUI();
            }

            if(Input.GetKeyDown(KeyCode.E)) {
                weaponSystem.PlayerShoot();
            }
            if(Input.GetKeyDown(KeyCode.F)) {
                weaponSystem.ChangeWeapon(i++);
            }

            if(!GameData.gameIsPaused && !GameData.playerIsDead) {
                float mx = Input.GetAxis("Mouse X") * mouseSensitivity;
                float my = Input.GetAxis("Mouse Y") * mouseSensitivity;
            }
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
    }
}

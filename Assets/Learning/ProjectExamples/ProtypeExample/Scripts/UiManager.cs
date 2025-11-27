
using UnityEngine;

namespace Learning.Prototype {
    public sealed class UiManager : MonoBehaviour {

        [SerializeField] UIHealthView healthView;
        [SerializeField] UIScoreView scoreView;
        [SerializeField] UIWeaponView weaponView;

        public PlayerHealth playerHealth;
        public WeaponSystem weaponSystem;

        private void Awake() {
            InitializeUI();
            AddGameEvents();
        }
        private void InitializeUI() {
            healthView?.Initialize();
            scoreView?.Initialize();
            weaponView?.Initialize();
        }
        private void AddGameEvents() {
            playerHealth.OnHealthChanged += HealthChanged;
            playerHealth.OnDeath += HealthDepleted;
            weaponSystem.OnWeaponChanged += ChangedWeapon;
            weaponSystem.OnAmmoChanged += ChangedAmmo;
        }
        private void HealthChanged(float healthPercent) {
            healthView.UpdateHealthbar(healthPercent);
        }
        private void HealthDepleted(int lives) {
            healthView.UpdatelivesUI(lives);
        }
        private void ChangedWeapon(int weaponIndex) {
            weaponView.UpdateWeaponUI(weaponIndex);
        }
        private void ChangedAmmo(int newAmmo) {
            weaponView.UpdateAmmoUI(newAmmo);
        }
        private void ChangedScore(int score) {
            scoreView.AddScore(score);
        }
    }
}

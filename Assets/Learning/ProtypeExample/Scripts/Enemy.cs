using System;
using UnityEngine;

namespace Learning.Prototype {
    public class Enemy : MonoBehaviour, IDamageable {

        public float CurrentHealth => currentHealth;
        public float HealthPercent => currentHealth / maxHealth;

        const float speed = 2f;

        private float maxHealth = 100f;
        private float currentHealth;
        private Transform playerTransform;
        private bool shouldMove;
        public void StartMovingTowards(Transform plTransform) {
            this.playerTransform = plTransform;
            shouldMove = true;
        }

        private void Update() {
            if(!playerTransform || !shouldMove) {
                return;
            }
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other) {
                if(other.TryGetComponent<IDamageable>(out var damageable)) {
                    damageable.TakeDamage(20f);
                    Destroy(gameObject);
                }

        }
        public void TakeDamage(float damage) {
            //Add score
            Destroy(gameObject);
        }
    }
}

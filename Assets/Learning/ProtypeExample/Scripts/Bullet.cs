using System;
using UnityEngine;

namespace Learning.Prototype {

    public class Bullet : MonoBehaviour
    {
        public float speed = 20f;
        // Update is called once per frame
        void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        private void OnTriggerEnter (Collider other)
        {
            if(other.gameObject.CompareTag("Enemy")) {
                if(other.TryGetComponent<IDamageable>(out var damageable)) {
                    damageable.TakeDamage(20f);
                }
            }
            Destroy(gameObject);
        }
    }
}


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

        private void OnCollisionEnter(Collision other) {
            if(other.gameObject.CompareTag("Enemy")) {
                Debug.Log("Bullet hit Enemy!");
                //Add score - call onDeath function in enemy
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}


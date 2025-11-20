using UnityEngine;

namespace Learning.Prototype {
    public class CameraControl : MonoBehaviour, ICameraControl {

        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float lookSpeed = 2f;
        [SerializeField] private Camera camera;
        
        public Camera CameraRef => camera;
        public float MoveSpeed => moveSpeed;
        public float LookSpeed => lookSpeed;
    }
}

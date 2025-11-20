using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Learning.Prototype {
    public class CameraControl : MonoBehaviour {
        public float moveSpeed = 5f;
        public float lookSpeed = 2f;
        public Camera camera;

        public Camera CurrentCamera { get; set; }


    }
}

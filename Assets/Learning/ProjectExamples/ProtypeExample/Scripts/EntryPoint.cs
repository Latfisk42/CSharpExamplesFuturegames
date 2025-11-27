<<<<<<< HEAD:Assets/Learning/ProtypeExample/Scripts/EntryPoint.cs
﻿using UnityEngine;

namespace Learning.Prototype {
    public class EntryPoint: MonoBehaviour {
        [SerializeField] private CameraControl cameraControlPrefab;
        private CameraHandler cameraHandler;
        private void Awake() {
            CameraControl cameraControl = Instantiate(cameraControlPrefab);
            cameraHandler = new CameraHandler(cameraControl);
        }
=======
﻿using Learning.Prototype;
using Learning.ProtypeExample.Scripts;
using UnityEngine;

namespace Learning.ProtypeExample {
    public class EntryPoint : MonoBehaviour {
        [SerializeField] private CameraControlWindows cameraControlWindowsPrefab;
        [SerializeField] private CameraControlAndroid cameraControlAndroidPrefab;

        private CameraHandler cameraHandler;
        private EntryPoint entryPoint;

        private void Awake() {
#if UNITY_ANDROID
            CameraControlAndroid cameraControlAndroid = Instantiate(cameraControlAndroidPrefab);
            cameraHandler = new CameraHandler(cameraControlAndroid);
#else
            CameraControlWindows cameraControlWindows = Instantiate(cameraControlWindowsPrefab);
            cameraHandler = new CameraHandler(cameraControlWindows);
#endif
        }

>>>>>>> upstream/main:Assets/Learning/ProjectExamples/ProtypeExample/Scripts/EntryPoint.cs
        private void Update() {
            cameraHandler?.Tick();
        }
    }
}

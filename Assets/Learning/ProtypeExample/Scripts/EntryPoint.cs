using UnityEngine;

namespace Learning.Prototype {
    public class EntryPoint: MonoBehaviour {
        [SerializeField] private CameraControl cameraControlPrefab;
        private CameraHandler cameraHandler;
        private void Awake() {
            CameraControl cameraControl = Instantiate(cameraControlPrefab);
            cameraHandler = new CameraHandler(cameraControl);
        }
        private void Update() {
            cameraHandler?.Tick();
        }
    }
}

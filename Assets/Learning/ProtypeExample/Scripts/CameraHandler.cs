using UnityEngine;

namespace Learning.Prototype {
    public class CameraHandler {
        private readonly CameraControl cameraControl;

        private float yaw = 0f;
        private float pitch = 0f;

        public CameraHandler(CameraControl cameraControl) {
            this.cameraControl = cameraControl;
        }

        public void Tick() {
            // Camera movement
            Camera camera = cameraControl.GetComponent<Camera>();

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 move = (camera.transform.right * h) + (camera.transform.forward * v);
            camera.transform.position += move * cameraControl.MoveSpeed * Time.deltaTime;

            // Camera rotation
            if(Input.GetMouseButton(1)) {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                yaw += cameraControl.LookSpeed * Input.GetAxis("Mouse X");
                pitch -= cameraControl.LookSpeed * Input.GetAxis("Mouse Y");
                pitch = Mathf.Clamp(pitch, -80f, 80f);
                camera.transform.eulerAngles = new Vector3(pitch, yaw, 0f);
            }
            else {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}

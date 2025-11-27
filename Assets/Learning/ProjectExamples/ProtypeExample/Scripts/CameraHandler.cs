using UnityEngine;

namespace Learning.Prototype {
<<<<<<< HEAD:Assets/Learning/ProtypeExample/Scripts/CameraHandler.cs
    public class CameraHandler {
        private readonly CameraControl cameraControl;

        private float yaw = 0f;
        private float pitch = 0f;

        public CameraHandler(CameraControl cameraControl) {
=======
public class CameraHandler {
        private readonly ICameraControl cameraControl;
        private float yaw = 0f;
        private float pitch = 0f;

        public CameraHandler(ICameraControl cameraControl) {
>>>>>>> upstream/main:Assets/Learning/ProjectExamples/ProtypeExample/Scripts/CameraHandler.cs
            this.cameraControl = cameraControl;
        }

        public void Tick() {
            // Camera movement
<<<<<<< HEAD:Assets/Learning/ProtypeExample/Scripts/CameraHandler.cs
            Camera camera = cameraControl.GetComponent<Camera>();

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 move = (camera.transform.right * h) + (camera.transform.forward * v);
            camera.transform.position += move * cameraControl.MoveSpeed * Time.deltaTime;
=======

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 move = (cameraControl.CameraRefReference.transform.right * h) + (cameraControl.CameraRefReference.transform.forward * v);
            cameraControl.CameraRefReference.transform.position += move * cameraControl.MoveSpeed * Time.deltaTime;
>>>>>>> upstream/main:Assets/Learning/ProjectExamples/ProtypeExample/Scripts/CameraHandler.cs

            // Camera rotation
            if(Input.GetMouseButton(1)) {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                yaw += cameraControl.LookSpeed * Input.GetAxis("Mouse X");
                pitch -= cameraControl.LookSpeed * Input.GetAxis("Mouse Y");
                pitch = Mathf.Clamp(pitch, -80f, 80f);
<<<<<<< HEAD:Assets/Learning/ProtypeExample/Scripts/CameraHandler.cs
                camera.transform.eulerAngles = new Vector3(pitch, yaw, 0f);
=======
                cameraControl.CameraRefReference.transform.eulerAngles = new Vector3(pitch, yaw, 0f);
>>>>>>> upstream/main:Assets/Learning/ProjectExamples/ProtypeExample/Scripts/CameraHandler.cs
            }
            else {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}

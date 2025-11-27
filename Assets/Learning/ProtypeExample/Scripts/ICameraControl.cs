using UnityEngine;

namespace Learning.Prototype {
    public interface ICameraControl {

        Camera CameraRef { get;}
        float MoveSpeed { get; }
        float LookSpeed { get; }
    }
}

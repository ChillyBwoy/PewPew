using UnityEngine;

namespace PewPew.Components
{
    public enum CameraMode
    {
        FirstPerson,
        ThirdPerson,
        FlyMode,
        Arena,
    }

    public struct CameraComponent
    {
        public Transform transform;
        public float distance;
        public float verticalOffset;
        public float cameraFocusRadius;
        public CameraMode mode;
        public Transform lookTarget;
    }
}

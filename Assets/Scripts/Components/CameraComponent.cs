using UnityEngine;

namespace PewPew.Components
{
    public struct CameraComponent
    {
        public Transform cameraTransform;
        public float cameraDistance;
        public float cameraVerticalOffset;
        public float cameraFocusRadius;
        public CameraState cameraState;

        public enum CameraState
        {
            FirstPerson = 0,
            ThirdPerson = 1,
        }
    }
}

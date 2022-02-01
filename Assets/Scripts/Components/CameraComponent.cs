using UnityEngine;
using PewPew.Data;

namespace PewPew.Components
{
    public struct CameraComponent
    {
        public Transform cameraTransform;
        public float cameraDistance;
        public float cameraVerticalOffset;
        public float cameraFocusRadius;
        public CameraMode cameraMode;
    }
}

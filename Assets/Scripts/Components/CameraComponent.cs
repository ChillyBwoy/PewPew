using UnityEngine;
using PewPew.Data;

namespace PewPew.Components
{
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

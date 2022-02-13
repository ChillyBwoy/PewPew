using UnityEngine;

namespace PewPew.Components.Camera
{
    public enum CameraMode
    {
        FirstPerson,
        SceneMode,
    }
    public struct CameraComponent
    {
        public CameraMode mode;
        public Transform target;
    }
}

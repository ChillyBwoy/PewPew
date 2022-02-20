using System;
using UnityEngine;

namespace PewPew.Components.Camera
{
    public enum CameraMode
    {
        FirstPerson,
        ThirdPerson,
        ThirdPersonFly,
    }

    [Serializable]
    public struct CameraComponent
    {
        public CameraMode mode;
        public Transform target;
    }
}

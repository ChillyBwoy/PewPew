using System;

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
    }
}

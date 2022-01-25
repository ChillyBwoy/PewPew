using System;
using UnityEngine;

namespace PewPew.Components
{
    [Serializable]
    public struct MouseLookDirectionComponent
    {
        public Transform cameraTransform;
        [HideInInspector] public Vector2 direction;
        [Range(0.1f, 2f)] public float mouseSensitivity;
    }
}
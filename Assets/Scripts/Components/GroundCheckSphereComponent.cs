using System;
using UnityEngine;

namespace PewPew.Components
{
    [Serializable]
    public struct GroundCheckSphereComponent
    {
        public LayerMask groundMask;
        public Transform groundCheckSphere;
        public float groundDistance;
        [HideInInspector] public bool isGrounded;
    }
}
using UnityEngine;

namespace PewPew.Components
{
    public struct GroundCheckSphereComponent
    {
        public LayerMask groundMask;
        public Transform groundCheckSphere;
        public float groundDistance;
        public bool isGrounded;
    }
}

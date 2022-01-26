using UnityEngine;

namespace PewPew.Components
{
    public struct MovableComponent
    {
        public CharacterController characterController;
        public float speed;
        public Vector3 velocity;
        public float gravity;
    }
}

using System;
using UnityEngine;

namespace PewPew.Components
{
    [Serializable]
    public struct MovableComponent
    {
        public CharacterController characterController;
        public float speed;
        public Vector3 velocity;
        public float gravity;
    }
}
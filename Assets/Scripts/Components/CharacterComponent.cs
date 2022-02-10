using System;
using UnityEngine;

namespace PewPew.Components
{
    [Serializable]
    public struct CharacterComponent
    {
        public bool isGrounded;
        public CapsuleCollider capsuleCollider;
        public Rigidbody rigidbody;
        public Transform head;
        public Transform body;
    }
}

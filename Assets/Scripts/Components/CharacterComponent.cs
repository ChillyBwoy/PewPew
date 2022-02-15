using System;
using UnityEngine;

namespace PewPew.Components
{
    [Serializable]
    public struct CharacterComponent
    {
        public Collider collider;
        public Rigidbody rigidbody;
    }
}

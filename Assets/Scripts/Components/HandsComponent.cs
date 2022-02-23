using System;
using UnityEngine;

namespace PewPew.Components
{
    [Serializable]
    public struct HandsComponent
    {
        [Header("Right")]
        public Transform rightShoulder;
        public Transform rightHand;

        [Header("Left")]
        public Transform leftShoulder;
        public Transform leftHand;
    }
}

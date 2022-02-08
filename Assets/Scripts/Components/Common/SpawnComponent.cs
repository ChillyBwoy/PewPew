using UnityEngine;

namespace PewPew.Components.Common
{
    public struct SpawnComponent
    {
        public GameObject prefab;
        public Vector3 position;
        public Quaternion rotation;
        public Transform parent;
    }
}

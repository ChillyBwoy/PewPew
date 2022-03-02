using System;
using UnityEngine;

namespace PewPew.Components
{
    [Serializable]
    public struct ProjectileSpawnerComponent
    {
        public GameObject prefab;
        public Transform spawnPoint;
    }
}

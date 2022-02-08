using UnityEngine;

using PewPew.Lib.Factories;

namespace PewPew.UnityComponents
{
    public class SceneData : MonoBehaviour
    {
        [Header("Common")]
        public PrefabFactory prefabFactory;

        [Header("Player")]
        public Transform playerSpawnPoint;

        [Header("Camera")]
        public Camera mainCamera;
    }
}

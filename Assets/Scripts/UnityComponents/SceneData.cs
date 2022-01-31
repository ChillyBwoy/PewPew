using UnityEngine;

namespace PewPew.UnityComponents
{
    public class SceneData : MonoBehaviour
    {
        [Header("Player")]
        public GameObject playerPrefab;
        public Transform playerSpawnPoint;

        [Header("Enemy")]
        public GameObject enemyPrefab;
        public Transform enemySpawnPoint;

        [Header("Camera")]
        public Camera mainCamera;
        [Range(1f, 5f)] public float cameraDistance = 2f;
        [Range(0f, 5f)] public float cameraVerticalOffset = 2f;
        [Range(0f, 3f)] public float cameraFocusRadius = 1f;

        [Header("Input")]
        [Range(0.1f, 2f)] public float mouseSensitivity = 1.5f;
    }
}

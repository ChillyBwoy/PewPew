using UnityEngine;

namespace PewPew.UnityComponents
{
    public class PlayerData : MonoBehaviour
    {
        [Header("Player")]
        public Transform playerLookAt;

        [Header("Camera")]
        public Transform cameraTransform;
        [Range(1f, 5f)] public float cameraDistance = 2f;
        [Range(0f, 5f)] public float cameraVerticalOffset = 2f;
        [Range(0f, 3f)] public float cameraFocusRadius = 1f;

        [Header("MouseLookDirection")]
        [Range(0.1f, 2f)] public float mouseSensitivity = 1.5f;
    }
}

using UnityEngine;

namespace PewPew.UnityComponents
{
    [CreateAssetMenu(menuName = "PewPew/StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        [Header("Player")]
        public GameObject playerPrefab;
        [Range(1f, 10f)] public float playerSpeed = 5f;

        [Header("Input")]
        [Range(0.1f, 2f)] public float lookSensitivity = 2f;
        [Range(1f, 5f)] public float jumpForce;
        [Range(1f, 5f)] public float jumpCooldown;

        [Header("Physics")]
        [Range(-100f, 100f)] public float gravity = -25f;
    }
}

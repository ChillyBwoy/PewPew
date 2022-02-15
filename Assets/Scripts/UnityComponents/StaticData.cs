using UnityEngine;

namespace PewPew.UnityComponents
{
    [CreateAssetMenu(menuName = "PewPew/StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        [Header("Player")]
        public GameObject playerPrefab;

        [Header("NPC")]
        public GameObject enemyPrefab;

        [Header("Input")]
        [Range(1f, 99f)] public float playerSpeed = 5f;
        [Range(1f, 99f)] public float lookSensitivity = 99f;
        [Range(1f, 100f)] public float jumpForce = 3.5f;

        [Header("Physics")]
        public Vector3 gravity = new Vector3(0, 9.81f, 0);
    }
}

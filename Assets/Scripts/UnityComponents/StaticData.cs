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
        [Range(1f, 99f)] public float lookSensitivity = 99f;

        [Header("Physics")]
        public Vector3 gravity;
    }
}

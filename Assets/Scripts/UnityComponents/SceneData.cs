using UnityEngine;
using Cinemachine;

using PewPew.Components.Camera;
using PewPew.Lib.Factories;

namespace PewPew.UnityComponents
{
    public class SceneData : MonoBehaviour
    {
        [Header("Common")]
        public PrefabFactory prefabFactory;

        [Header("Player")]
        public Transform playerSpawnPoint;

        [Header("NPC")]
        public Transform[] enemySpawnPoints;

        [Header("Camera")]
        public CinemachineVirtualCamera mainCamera;
        public CameraMode cameraMode;
    }
}

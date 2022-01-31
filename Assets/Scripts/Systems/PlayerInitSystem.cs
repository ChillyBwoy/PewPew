using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;
using PewPew.UnityComponents;

namespace PewPew.Systems
{
    sealed class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld world = null;
        private readonly SceneData sceneData;

        public void Init()
        {
            EcsEntity entity = world.NewEntity();

            ref var playerComponent = ref entity.Get<PlayerComponent>();
            ref var movableComponent = ref entity.Get<MovableComponent>();
            ref var modelComponent = ref entity.Get<ModelComponent>();
            ref var directionComponent = ref entity.Get<DirectionComponent>();
            ref var cameraComponent = ref entity.Get<CameraComponent>();
            ref var mouseLookDirectionComponent = ref entity.Get<MouseLookDirectionComponent>();
            ref var groundCheckSphereComponent = ref entity.Get<GroundCheckSphereComponent>();
            ref var jumpComponent = ref entity.Get<JumpComponent>();

            GameObject go = Object.Instantiate(
                sceneData.playerPrefab,
                sceneData.playerSpawnPoint.position,
                Quaternion.identity
            );

            PlayerData playerData = go.GetComponent<PlayerData>();

            playerComponent.lookAt = playerData.playerLookAt;

            movableComponent.characterController = playerData.characterController;
            movableComponent.speed = playerData.speed;
            movableComponent.gravity = playerData.gravity;

            modelComponent.modelTransform = go.transform;

            directionComponent.direction = Vector3.forward;

            mouseLookDirectionComponent.mouseSensitivity = playerData.mouseSensitivity;

            cameraComponent.cameraDistance = playerData.cameraDistance;
            cameraComponent.cameraFocusRadius = playerData.cameraFocusRadius;
            cameraComponent.cameraTransform = playerData.cameraTransform != null ? playerData.cameraTransform : sceneData.mainCamera.transform;
            cameraComponent.cameraVerticalOffset = playerData.cameraVerticalOffset;
            cameraComponent.cameraState = CameraComponent.CameraState.FirstPerson;

            groundCheckSphereComponent.groundCheckSphere = playerData.groundCheckSphere;
            groundCheckSphereComponent.groundDistance = playerData.groundDistance;
            groundCheckSphereComponent.groundMask = playerData.groundMask;

            jumpComponent.jumpCooldown = playerData.jumpCooldown;
            jumpComponent.jumpForce = playerData.jumpForce;
        }
    }
}

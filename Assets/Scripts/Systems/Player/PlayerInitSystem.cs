using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;
using PewPew.Data;
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
            ref var lookDirectionComponent = ref entity.Get<LookDirectionComponent>();
            ref var groundCheckSphereComponent = ref entity.Get<GroundCheckSphereComponent>();
            ref var jumpComponent = ref entity.Get<JumpComponent>();

            GameObject go = Object.Instantiate(
                sceneData.playerPrefab,
                sceneData.playerSpawnPoint.position,
                Quaternion.identity
            );

            MovableData movableData = go.GetComponent<MovableData>();
            GroundCheckData groundCheckData = go.GetComponent<GroundCheckData>();
            JumpData jumpData = go.GetComponent<JumpData>();

            movableComponent.characterController = movableData.characterController;
            movableComponent.speed = movableData.speed;
            movableComponent.gravity = movableData.gravity;

            modelComponent.modelTransform = go.transform;

            directionComponent.direction = Vector3.forward;

            lookDirectionComponent.sensitivity = sceneData.lookSensitivity;

            cameraComponent.cameraTransform = sceneData.mainCamera.transform;
            cameraComponent.cameraDistance = sceneData.cameraDistance;
            cameraComponent.cameraFocusRadius = sceneData.cameraFocusRadius;
            cameraComponent.cameraVerticalOffset = sceneData.cameraVerticalOffset;
            cameraComponent.cameraMode = sceneData.cameraMode;

            groundCheckSphereComponent.groundCheckSphere = groundCheckData.groundCheckSphere;
            groundCheckSphereComponent.groundDistance = groundCheckData.groundDistance;
            groundCheckSphereComponent.groundMask = groundCheckData.groundMask;

            jumpComponent.jumpCooldown = jumpData.jumpCooldown;
            jumpComponent.jumpForce = jumpData.jumpForce;
        }
    }
}

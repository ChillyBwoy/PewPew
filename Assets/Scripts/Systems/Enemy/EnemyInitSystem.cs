using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;
using PewPew.UnityComponents;

namespace PewPew.Systems
{
    sealed class EnemyInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld world = null;
        private readonly SceneData sceneData;
        public void Init()
        {
            EcsEntity entity = world.NewEntity();

            ref var enemyComponent = ref entity.Get<EnemyComponent>();
            ref var modelComponent = ref entity.Get<ModelComponent>();
            ref var movableComponent = ref entity.Get<MovableComponent>();
            ref var directionComponent = ref entity.Get<DirectionComponent>();
            ref var groundCheckSphereComponent = ref entity.Get<GroundCheckSphereComponent>();
            ref var jumpComponent = ref entity.Get<JumpComponent>();

            GameObject go = Object.Instantiate(
                sceneData.enemyPrefab,
                sceneData.enemySpawnPoint.position,
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

            groundCheckSphereComponent.groundCheckSphere = groundCheckData.groundCheckSphere;
            groundCheckSphereComponent.groundDistance = groundCheckData.groundDistance;
            groundCheckSphereComponent.groundMask = groundCheckData.groundMask;

            jumpComponent.jumpCooldown = jumpData.jumpCooldown;
            jumpComponent.jumpForce = jumpData.jumpForce;
        }
    }
}

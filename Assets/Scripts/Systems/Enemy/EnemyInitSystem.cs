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

            ref EnemyComponent enemy = ref entity.Get<EnemyComponent>();
            ref ModelComponent model = ref entity.Get<ModelComponent>();
            ref MovableComponent movable = ref entity.Get<MovableComponent>();
            ref GroundCheckSphereComponent groundCheckSphere = ref entity.Get<GroundCheckSphereComponent>();
            ref JumpComponent jump = ref entity.Get<JumpComponent>();

            GameObject go = Object.Instantiate(
                sceneData.enemyPrefab,
                sceneData.enemySpawnPoint.position,
                Quaternion.identity
            );

            MovableData movableData = go.GetComponent<MovableData>();
            GroundCheckData groundCheckData = go.GetComponent<GroundCheckData>();
            JumpData jumpData = go.GetComponent<JumpData>();

            model.modelTransform = go.transform;

            movable.characterController = movableData.characterController;
            movable.speed = movableData.speed;
            movable.gravity = movableData.gravity;
            movable.direction = Vector3.forward;

            groundCheckSphere.groundCheckSphere = groundCheckData.groundCheckSphere;
            groundCheckSphere.groundDistance = groundCheckData.groundDistance;
            groundCheckSphere.groundMask = groundCheckData.groundMask;

            jump.jumpCooldown = jumpData.jumpCooldown;
            jump.jumpForce = jumpData.jumpForce;
        }
    }
}

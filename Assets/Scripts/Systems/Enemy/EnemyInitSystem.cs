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

            ref var enemy = ref entity.Get<EnemyComponent>();
            ref var character = ref entity.Get<CharacterComponent>();
            ref var model = ref entity.Get<ModelComponent>();
            ref var movable = ref entity.Get<MovableComponent>();
            ref var groundCheckSphere = ref entity.Get<GroundCheckSphereComponent>();
            ref var jump = ref entity.Get<JumpComponent>();

            GameObject go = Object.Instantiate(
                sceneData.enemyPrefab,
                sceneData.enemySpawnPoint.position,
                Quaternion.identity
            );

            CharacterData characterData = go.GetComponent<CharacterData>();
            MovableData movableData = go.GetComponent<MovableData>();
            GroundCheckData groundCheckData = go.GetComponent<GroundCheckData>();
            JumpData jumpData = go.GetComponent<JumpData>();

            character.eyesTransform = characterData.eyesTransform;

            model.modelTransform = go.transform;

            movable.characterController = movableData.characterController;
            movable.speed = movableData.speed;
            movable.gravity = movableData.gravity;
            movable.direction = Vector3.zero;

            groundCheckSphere.groundCheckSphere = groundCheckData.groundCheckSphere;
            groundCheckSphere.groundDistance = groundCheckData.groundDistance;
            groundCheckSphere.groundMask = groundCheckData.groundMask;

            jump.jumpCooldown = jumpData.jumpCooldown;
            jump.jumpForce = jumpData.jumpForce;
        }
    }
}

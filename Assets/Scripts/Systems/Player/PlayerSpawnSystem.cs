using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;
using PewPew.Components.Input;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Player
{
    sealed class PlayerSpawnSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly StaticData _staticData = null;
        private readonly SceneData _sceneData = null;

        private EcsEntity playerEntity;

        public void Init()
        {
            playerEntity = _world.NewEntity();

            Vector3 initialPosition = _sceneData.playerSpawnPoint.transform.position;
            Quaternion initialRotation = _sceneData.playerSpawnPoint.transform.rotation;

            playerEntity.Get<SpawnComponent>() = new SpawnComponent
            {
                prefab = _staticData.playerPrefab,
                position = initialPosition,
                rotation = initialRotation,
                parent = null,
            };
            playerEntity.Get<PlayerTag>();
            playerEntity.Get<DirectionComponent>() = new DirectionComponent { value = Vector3.forward };
            playerEntity.Get<RotationComponent>() = new RotationComponent { value = initialRotation };
            playerEntity.Get<VelocityComponent>();
            playerEntity.Get<InputDirectionComponent>();
            playerEntity.Get<InputAxisComponent>();
        }
    }
}

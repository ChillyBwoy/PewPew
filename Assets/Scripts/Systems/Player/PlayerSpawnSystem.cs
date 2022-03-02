using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;
using PewPew.Components.Input;
using PewPew.Components.Tags;
using PewPew.Services;
using PewPew.UnityComponents;

namespace PewPew.Systems.Player
{
    sealed class PlayerSpawnSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly StaticData _staticData = null;
        private readonly SceneData _sceneData = null;
        private readonly RuntimeData _runtimeData = null;

        public void Init()
        {
            // check if there is already a player created
            if (_runtimeData.PlayerEntity != null)
                return;

            EcsEntity entity = _world.NewEntity();

            Transform spawnPoint = _sceneData.playerSpawnPoint.transform;

            entity.Get<SpawnComponent>() = new SpawnComponent
            {
                prefab = _staticData.playerPrefab,
                position = spawnPoint.position,
                rotation = spawnPoint.rotation,
                parent = null,
            };
            entity.Get<PlayerTag>();
            entity.Get<DirectionComponent>() = new DirectionComponent { value = Vector3.zero };
            entity.Get<RotationComponent>() = new RotationComponent { value = spawnPoint.rotation };
            entity.Get<VelocityComponent>() = new VelocityComponent { value = Vector3.zero };
            entity.Get<InputAxisComponent>();
            entity.Get<CameraTargetTag>();
            entity.Get<InventoryComponent>() = new InventoryComponent
            {
                items = new List<InventoryItemComponent>()
            };

            _runtimeData.PlayerEntity = entity;
        }
    }
}

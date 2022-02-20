using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;
using PewPew.Components.Events;
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
        private readonly EcsFilter<PlayerTag> _playerFilter = null;

        public void Init()
        {
            // check if there is already a player created
            if (!_playerFilter.IsEmpty())
            {
                return;
            }

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
            entity.Get<CameraTargetTag>();
            entity.Get<DirectionComponent>() = new DirectionComponent { value = Vector3.zero };
            entity.Get<RotationComponent>() = new RotationComponent { value = spawnPoint.rotation };
            entity.Get<VelocityComponent>() = new VelocityComponent { value = Vector3.zero };
            entity.Get<InputAxisComponent>();
            entity.Get<PlayerSpawnEvent>();
        }
    }
}

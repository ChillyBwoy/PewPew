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

            playerEntity.Get<SpawnComponent>() = new SpawnComponent
            {
                prefab = _staticData.playerPrefab,
                position = _sceneData.playerSpawnPoint.transform.position,
                rotation = _sceneData.playerSpawnPoint.transform.rotation,
                parent = null,
            };
            playerEntity.Get<PlayerTag>();
            playerEntity.Get<DirectionComponent>();
            playerEntity.Get<VelocityComponent>();
            playerEntity.Get<InputDirectionComponent>();
        }
    }
}

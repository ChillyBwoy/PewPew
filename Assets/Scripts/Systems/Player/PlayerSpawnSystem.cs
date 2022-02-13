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

        public void Init()
        {
            EcsEntity entity = _world.NewEntity();

            Vector3 initialPosition = _sceneData.playerSpawnPoint.transform.position;
            Quaternion initialRotation = _sceneData.playerSpawnPoint.transform.rotation;

            entity.Get<SpawnComponent>() = new SpawnComponent
            {
                prefab = _staticData.playerPrefab,
                position = initialPosition,
                rotation = initialRotation,
                parent = null,
            };
            entity.Get<PlayerTag>();
            entity.Get<CameraTargetTag>();
            entity.Get<DirectionComponent>() = new DirectionComponent { value = Vector3.forward };
            entity.Get<RotationComponent>() = new RotationComponent { value = initialRotation };
            entity.Get<VelocityComponent>();
            entity.Get<InputDirectionComponent>();
            entity.Get<InputAxisComponent>();
        }
    }
}

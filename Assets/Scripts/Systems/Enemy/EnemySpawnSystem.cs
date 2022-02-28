using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;
using PewPew.Components.Events;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Enemy
{
    sealed class EnemySpawnSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<EnemySpawnEvent> _filter = null;
        private readonly StaticData _staticData = null;
        private readonly SceneData _sceneData = null;
        private int spawnPointIndex = 0;

        public void Run()
        {
            if (_filter.IsEmpty())
                return;

            EcsEntity entity = _world.NewEntity();

            Transform spawnPoint = _sceneData.enemySpawnPoints[spawnPointIndex].transform;

            spawnPointIndex++;
            if (spawnPointIndex >= _sceneData.enemySpawnPoints.Length)
            {
                spawnPointIndex = 0;
            }

            entity.Get<SpawnComponent>() = new SpawnComponent
            {
                prefab = _staticData.enemyPrefab,
                position = spawnPoint.position,
                rotation = spawnPoint.rotation,
                parent = null,
            };
            entity.Get<EnemyTag>();
            entity.Get<DirectionComponent>() = new DirectionComponent { value = Vector3.zero };
            entity.Get<RotationComponent>() = new RotationComponent { value = spawnPoint.rotation };
            entity.Get<VelocityComponent>() = new VelocityComponent { value = Vector3.zero };
        }
    }
}

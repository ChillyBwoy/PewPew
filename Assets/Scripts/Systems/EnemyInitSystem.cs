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
            EcsEntity enemy = world.NewEntity();

            ref var enemyComponent = ref enemy.Get<EnemyComponent>();
            ref var modelComponent = ref enemy.Get<ModelComponent>();
            ref var directionCompontn = ref enemy.Get<DirectionComponent>();

            GameObject go = Object.Instantiate(
                sceneData.enemyPrefab,
                sceneData.enemySpawnPoint.position,
                Quaternion.identity
            );

            EnemyData enemyData = go.GetComponent<EnemyData>();

            modelComponent.modelTransform = go.transform;

            directionCompontn.direction = Vector3.forward;
        }
    }
}

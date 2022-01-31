using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;

namespace PewPew.Systems
{
    sealed class EnemyMovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, ModelComponent> playerFilter = null;
        private readonly EcsFilter<EnemyComponent, ModelComponent, MovableComponent, DirectionComponent> enemyFilter = null;

        private EcsEntity playerEntity;

        public void Init()
        {
            playerEntity = playerFilter.GetEntity(0);
        }

        public void Run()
        {
            ref var playerModelComponent = ref playerEntity.Get<ModelComponent>();

            foreach (var i in enemyFilter)
            {
                ref DirectionComponent directionComponent = ref enemyFilter.Get4(i);

                directionComponent.direction = playerModelComponent.modelTransform.transform.position;

                // ref ModelComponent modelComponent = ref enemyFilter.Get2(i);

                // Vector3 target = playerModelComponent.modelTransform.transform.position - modelComponent.modelTransform.transform.position;
                // Quaternion rotation = Quaternion.LookRotation(-target, Vector3.up);

                // modelComponent.modelTransform.rotation = Quaternion.Slerp(
                //     modelComponent.modelTransform.rotation,
                //     rotation,
                //     Time.deltaTime * 3f
                // );
                // modelComponent.modelTransform.position = Vector3.Lerp(
                //     modelComponent.modelTransform.position,
                //     playerModelComponent.modelTransform.position,
                //     Time.deltaTime * 0.1f
                // );
            }
        }
    }
}

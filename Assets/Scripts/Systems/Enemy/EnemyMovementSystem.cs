using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;
using PewPew.UnityComponents;

namespace PewPew.Systems
{
    sealed class EnemyMovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, ModelComponent> playerFilter = null;
        private readonly EcsFilter<EnemyComponent, ModelComponent, MovableComponent> enemyFilter = null;
        private readonly SceneData sceneData = null;
        private EcsEntity playerEntity;

        public void Init()
        {
            playerEntity = playerFilter.GetEntity(0);
        }

        public void Run()
        {
            ref var playerModel = ref playerEntity.Get<ModelComponent>();

            foreach (var i in enemyFilter)
            {
                ref ModelComponent model = ref enemyFilter.Get2(i);
                ref MovableComponent movable = ref enemyFilter.Get3(i);

                Vector3 targetPos = playerModel.modelTransform.transform.position;
                model.modelTransform.LookAt(targetPos);

                float distance = Vector3.Distance(targetPos, model.modelTransform.position);
                if (distance > 7.5f)
                {
                    movable.direction = Vector3.forward;
                }
                else
                {
                    movable.direction = Vector3.zero;
                }
            }
        }
    }
}

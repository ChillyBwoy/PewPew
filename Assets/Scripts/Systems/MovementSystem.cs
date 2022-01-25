using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;

namespace PewPew.Systems
{
    sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;

        private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> movableFilter = null;

        public void Run()
        {
            foreach (var i in movableFilter)
            {
                ref var modelComponent = ref movableFilter.Get1(i);
                ref var movableComponent = ref movableFilter.Get2(i);
                ref var directionComponent = ref movableFilter.Get3(i);

                ref var direction = ref directionComponent.direction;
                ref var transform = ref modelComponent.modelTransform;

                ref var characterController = ref movableComponent.characterController;
                ref var speed = ref movableComponent.speed;

                var rawDirecrtion = (transform.right * direction.x) + (transform.forward * direction.z);

                ref var velocity = ref movableComponent.velocity;
                velocity.y += movableComponent.gravity * Time.deltaTime;

                characterController.Move(rawDirecrtion * speed * Time.deltaTime);
                characterController.Move(velocity * Time.deltaTime);
            }
        }
    }
}

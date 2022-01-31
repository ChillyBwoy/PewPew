using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;

namespace PewPew.Systems
{

    sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> movableFilter = null;

        public void Run()
        {
            foreach (var i in movableFilter)
            {
                ref ModelComponent modelComponent = ref movableFilter.Get1(i);
                ref MovableComponent movableComponent = ref movableFilter.Get2(i);
                ref DirectionComponent directionComponent = ref movableFilter.Get3(i);

                ref Vector3 direction = ref directionComponent.direction;
                ref Transform transform = ref modelComponent.modelTransform;

                ref CharacterController characterController = ref movableComponent.characterController;
                ref float speed = ref movableComponent.speed;

                Vector3 rawDirecrtion = (transform.right * direction.x) + (transform.forward * direction.z);

                ref Vector3 velocity = ref movableComponent.velocity;
                velocity.y += movableComponent.gravity * Time.deltaTime;

                characterController.Move(rawDirecrtion * speed * Time.deltaTime);
                characterController.Move(velocity * Time.deltaTime);
            }
        }
    }
}

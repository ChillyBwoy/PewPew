using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;

namespace PewPew.Systems
{
    sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ModelComponent, MovableComponent> movableFilter = null;

        public void Run()
        {
            foreach (var i in movableFilter)
            {
                ref ModelComponent model = ref movableFilter.Get1(i);
                ref MovableComponent movable = ref movableFilter.Get2(i);

                ref Vector3 direction = ref movable.direction;
                ref Transform transform = ref model.modelTransform;

                ref CharacterController characterController = ref movable.characterController;
                ref float speed = ref movable.speed;

                Vector3 rawDirecrtion = (transform.right * direction.x) + (transform.forward * direction.z);

                ref Vector3 velocity = ref movable.velocity;
                velocity.y += movable.gravity * Time.deltaTime;

                characterController.Move(rawDirecrtion * speed * Time.deltaTime);
                characterController.Move(velocity * Time.deltaTime);
            }
        }
    }
}

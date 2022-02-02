using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;

namespace PewPew.Systems
{

    sealed class PlayerMovableInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, MovableComponent> filter = null;

        public void Run()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            foreach (var i in filter)
            {
                ref MovableComponent movable = ref filter.Get2(i);

                movable.direction.x = moveX;
                movable.direction.z = moveZ;
            }
        }
    }
}

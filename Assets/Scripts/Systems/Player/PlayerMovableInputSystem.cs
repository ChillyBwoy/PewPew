using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;

namespace PewPew.Systems
{

    sealed class PlayerMovableInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, MovableComponent> directionFilter = null;

        public void Run()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            foreach (var i in directionFilter)
            {
                ref MovableComponent movable = ref directionFilter.Get2(i);
                ref var direction = ref movable.direction;

                direction.x = moveX;
                direction.z = moveZ;
            }
        }
    }
}

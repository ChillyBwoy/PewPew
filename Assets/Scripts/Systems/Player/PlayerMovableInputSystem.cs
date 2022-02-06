using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.UnityComponents;

namespace PewPew.Systems
{

    sealed class PlayerMovableInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, MovableComponent> filter = null;
        private readonly GameControls gameControls = null;

        public void Run()
        {
            Vector2 move = gameControls.Player.Move.ReadValue<Vector2>();

            foreach (var i in filter)
            {
                ref MovableComponent movable = ref filter.Get2(i);

                movable.direction.x = move.x;
                movable.direction.z = move.y;
            }
        }
    }
}

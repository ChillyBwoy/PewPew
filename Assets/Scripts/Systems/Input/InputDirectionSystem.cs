using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components.Input;
using PewPew.UnityComponents;

namespace PewPew.Systems.Input
{

    sealed class InputDirectionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputDirectionComponent> _filter = null;
        private readonly GameControls _gameControls = null;

        public void Run()
        {
            Vector2 move = _gameControls.Player.Move.ReadValue<Vector2>();

            foreach (var i in _filter)
            {
                ref InputDirectionComponent inputDirection = ref _filter.Get1(i);

                inputDirection.value.x = move.x;
                inputDirection.value.z = move.y;
            }
        }
    }
}

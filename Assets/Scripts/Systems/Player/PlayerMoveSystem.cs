using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Input;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Player
{
    sealed class PlayerMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent, InputDirectionComponent> _filter = null;
        private readonly StaticData _staticData = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref DirectionComponent direction = ref _filter.Get2(i);
                ref InputDirectionComponent inputDirection = ref _filter.Get3(i);

                direction.value = new Vector3(inputDirection.value.x, direction.value.y, inputDirection.value.z);
            }
        }
    }
}

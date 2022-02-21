using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Input;
using PewPew.Components.Tags;

namespace PewPew.Systems.Player
{
    sealed class PlayerRotationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, RotationComponent, InputAxisComponent> _filter = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref RotationComponent rotation = ref _filter.Get2(i);
                ref InputAxisComponent axis = ref _filter.Get3(i);

                float yRotation = rotation.value.y + axis.value.x;
                rotation.value = Quaternion.Euler(0, yRotation, 0);
            }
        }
    }
}

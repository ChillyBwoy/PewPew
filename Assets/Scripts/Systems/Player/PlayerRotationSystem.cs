using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Input;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Player
{
    sealed class PlayerRotationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, RotationComponent, InputAxisComponent> _filter = null;

        private readonly StaticData _staticData = null;

        private float _rotationX;
        private float _rotationY;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref RotationComponent rotation = ref _filter.Get2(i);
                ref InputAxisComponent axis = ref _filter.Get3(i);

                _rotationX += axis.value.x * _staticData.lookSensitivity;
                // _rotationY -= axis.value.y * _staticData.lookSensitivity;
                _rotationX = Mathf.Repeat(_rotationX, 360);
                // _rotationY = Mathf.Clamp(_rotationY, -60f, 60f);

                // rotation.value = Quaternion.Euler(_rotationY, _rotationX, 0);
                rotation.value = Quaternion.Euler(0, _rotationX, 0);
            }
        }
    }
}

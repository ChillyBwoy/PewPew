using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components.Input;
using PewPew.UnityComponents;

namespace PewPew.Systems.Input
{
    sealed class InputAxisSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<InputAxisComponent> _filter = null;
        private readonly GameControls _gameControls = null;
        private readonly StaticData _staticData = null;

        private Vector2 _value;

        public void Init()
        {
            _value = _gameControls.Player.Rotation.ReadValue<Vector2>();
        }

        public void Run()
        {
            _value = _gameControls.Player.Rotation.ReadValue<Vector2>();

            foreach (var i in _filter)
            {
                ref InputAxisComponent inputAxis = ref _filter.Get1(i);
                inputAxis.value = _value.normalized * _staticData.lookSensitivity;
            }
        }
    }
}

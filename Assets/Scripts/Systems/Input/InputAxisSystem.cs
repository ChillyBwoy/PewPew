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
        private float _axisX;
        private float _axisY;

        public void Init()
        {
            Vector2 value = _gameControls.Player.Look.ReadValue<Vector2>();
            _axisX = value.x;
            _axisY = value.y;
        }

        public void Run()
        {
            Vector2 value = _gameControls.Player.Look.ReadValue<Vector2>();

            _axisX += value.x;
            _axisY -= value.y;

            foreach (var i in _filter)
            {
                ref InputAxisComponent inputAxis = ref _filter.Get1(i);

                inputAxis.value.x = _axisX;
                inputAxis.value.y = Mathf.Clamp(_axisY, -45, 45);
            }
        }
    }
}

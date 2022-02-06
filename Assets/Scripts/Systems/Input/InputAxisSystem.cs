using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;
using PewPew.UnityComponents;

namespace PewPew.Systems
{
    sealed class InputAxisSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<InputAxisComponent> filter = null;
        private readonly GameControls gameControls = null;
        private float axisX;
        private float axisY;

        public void Init()
        {
            Vector2 value = gameControls.Player.Look.ReadValue<Vector2>();
            axisX = value.x;
            axisY = value.y;
        }

        public void Run()
        {
            Vector2 value = gameControls.Player.Look.ReadValue<Vector2>();

            axisX += value.x;
            axisY -= value.y;

            foreach (var i in filter)
            {
                ref InputAxisComponent axis = ref filter.Get1(i);

                axis.axis.x = axisX;
                axis.axis.y = Mathf.Clamp(axisY, -45, 45);
            }
        }
    }
}

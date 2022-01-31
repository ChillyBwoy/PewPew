using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;

namespace PewPew.Systems
{
    sealed class PlayerMouseInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MouseLookDirectionComponent> filter = null;

        private float axisX;
        private float axisY;

        public void Run()
        {
            axisX += Input.GetAxis("Mouse X");
            axisY -= Input.GetAxis("Mouse Y");

            foreach (var i in filter)
            {
                ref var lookComponent = ref filter.Get1(i);

                lookComponent.direction.x = axisX;
                lookComponent.direction.y = axisY;
            }
        }
    }
}
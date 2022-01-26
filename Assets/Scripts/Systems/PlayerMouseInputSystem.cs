using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;

namespace PewPew.Systems
{

    sealed class PlayerMouseInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, MouseLookDirectionComponent> playerFilter = null;

        private float axisX;
        private float axisY;

        public void Run()
        {
            GetAxis();
            ClampAxis();

            foreach (var i in playerFilter)
            {
                ref var lookComponent = ref playerFilter.Get2(i);

                lookComponent.direction.x = axisX;
                lookComponent.direction.y = axisY;
            }
        }

        private void GetAxis()
        {
            axisX += Input.GetAxis("Mouse X");
            axisY -= Input.GetAxis("Mouse Y");
        }

        private void ClampAxis()
        {
            // TODO
        }
    }
}
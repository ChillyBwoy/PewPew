using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{
    sealed class InputAxisSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<InputAxisComponent> filter = null;
        private float axisX;
        private float axisY;

        public void Init()
        {
            axisX = Input.GetAxis("Mouse X");
            axisY = Input.GetAxis("Mouse Y");
        }

        public void Run()
        {
            axisX += Input.GetAxis("Mouse X");
            axisY -= Input.GetAxis("Mouse Y");

            foreach (var i in filter)
            {
                ref InputAxisComponent axis = ref filter.Get1(i);

                axis.axis.x = axisX;
                axis.axis.y = Mathf.Clamp(axisY, -45, 45);
            }
        }
    }
}

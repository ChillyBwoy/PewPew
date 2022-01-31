using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraComponent> cameraFilter = null;

        public void Run()
        {
            foreach (var i in cameraFilter)
            {
                ref EcsEntity cameraEntity = ref cameraFilter.GetEntity(i);

                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    cameraEntity.Get<CameraChangeStateEvent>();
                }
            }
        }
    }
}

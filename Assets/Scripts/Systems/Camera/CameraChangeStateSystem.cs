using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;
using PewPew.Data;

namespace PewPew.Systems
{
    sealed class CameraChangeStateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraComponent, CameraChangeStateEvent> cameraFilter = null;
        public void Run()
        {
            foreach (var i in cameraFilter)
            {
                ref CameraComponent camera = ref cameraFilter.Get1(i);
                ref CameraChangeStateEvent cameraChangeState = ref cameraFilter.Get2(i);

                camera.mode = cameraChangeState.cameraMode;
            }
        }
    }
}

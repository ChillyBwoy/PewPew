using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{
    sealed class CameraChangeStateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraComponent, CameraChangeStateEvent> cameraFilter = null;
        public void Run()
        {
            foreach (var i in cameraFilter)
            {
                ref CameraComponent cameraComponent = ref cameraFilter.Get1(i);

                switch (cameraComponent.cameraState)
                {
                    case CameraComponent.CameraState.FirstPerson:
                        cameraComponent.cameraState = CameraComponent.CameraState.ThirdPerson;
                        break;

                    case CameraComponent.CameraState.ThirdPerson:
                        cameraComponent.cameraState = CameraComponent.CameraState.FirstPerson;
                        break;
                }
            }
        }
    }
}

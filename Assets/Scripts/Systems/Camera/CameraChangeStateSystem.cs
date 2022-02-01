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
                ref CameraComponent cameraComponent = ref cameraFilter.Get1(i);

                switch (cameraComponent.cameraMode)
                {
                    case CameraMode.FirstPerson:
                        cameraComponent.cameraMode = CameraMode.ThirdPerson;
                        break;

                    case CameraMode.ThirdPerson:
                        cameraComponent.cameraMode = CameraMode.FirstPerson;
                        break;
                }
            }
        }
    }
}

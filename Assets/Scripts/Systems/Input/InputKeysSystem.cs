using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;
using PewPew.Data;

namespace PewPew.Systems
{
    // TODO: придумать как избавиться от хардкода
    sealed class InputKeysSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraComponent> cameraFilter = null;

        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.Tab))
                return;

            foreach (var i in cameraFilter)
            {
                ref EcsEntity cameraEntity = ref cameraFilter.GetEntity(i);
                ref CameraComponent camera = ref cameraFilter.Get1(i);

                switch (camera.mode)
                {
                    case CameraMode.FirstPerson:
                        cameraEntity.Get<CameraChangeStateEvent>().cameraMode = CameraMode.ThirdPerson;
                        break;

                    case CameraMode.ThirdPerson:
                        cameraEntity.Get<CameraChangeStateEvent>().cameraMode = CameraMode.FlyMode;
                        break;

                    case CameraMode.FlyMode:
                        cameraEntity.Get<CameraChangeStateEvent>().cameraMode = CameraMode.Arena;
                        break;

                    case CameraMode.Arena:
                        cameraEntity.Get<CameraChangeStateEvent>().cameraMode = CameraMode.FirstPerson;
                        break;
                }
            }
        }
    }
}

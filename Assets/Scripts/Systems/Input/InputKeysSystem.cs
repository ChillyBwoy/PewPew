using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;
using PewPew.Data;

namespace PewPew.Systems
{
    // TODO: придумать как избавиться от хардкода
    sealed class InputKeysSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<CameraComponent> cameraFilter = null;
        private readonly EcsFilter<PlayerComponent, ModelComponent> playerFilter = null;
        private Transform cameraTarget;

        public void Init()
        {
            foreach (var i in playerFilter)
            {
                ref ModelComponent model = ref playerFilter.Get2(i);
                cameraTarget = model.modelTransform;
            }
        }

        public void Run()
        {
            foreach (var i in cameraFilter)
            {
                ref EcsEntity cameraEntity = ref cameraFilter.GetEntity(i);
                ref CameraComponent camera = ref cameraFilter.Get1(i);

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    cameraEntity.Get<CameraChangeStateEvent>().cameraMode = CameraMode.None;
                    camera.cameraTarget = null;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    cameraEntity.Get<CameraChangeStateEvent>().cameraMode = CameraMode.FirstPerson;
                    camera.cameraTarget = cameraTarget;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    cameraEntity.Get<CameraChangeStateEvent>().cameraMode = CameraMode.ThirdPerson;
                    camera.cameraTarget = cameraTarget;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    cameraEntity.Get<CameraChangeStateEvent>().cameraMode = CameraMode.FlyMode;
                    camera.cameraTarget = null;
                }
            }
        }
    }
}

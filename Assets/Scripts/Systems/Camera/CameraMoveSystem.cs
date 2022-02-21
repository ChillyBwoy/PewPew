using Cinemachine;
using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Camera;
using PewPew.Components.Input;
using PewPew.UnityComponents;

namespace PewPew.Systems.Camera
{
    sealed class CameraMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraComponent, InputAxisComponent> _cameraFilter = null;
        private readonly SceneData _sceneData = null;

        public void Run()
        {
            if (_cameraFilter.IsEmpty())
            {
                return;
            }

            ref EcsEntity entity = ref _cameraFilter.GetEntity(0);

            if (!entity.Has<CameraComponent>())
            {
                return;
            }

            ref var camera = ref entity.Get<CameraComponent>();
            ref var inputAxis = ref entity.Get<InputAxisComponent>();

            CinemachineVirtualCamera mainCamera = _sceneData.mainCamera;
            Transform target = camera.target;

            if (!target)
            {
                return;
            }

            switch (camera.mode)
            {
                case CameraMode.FirstPerson:
                    {
                        ref var rotation = ref entity.Get<RotationComponent>();

                        mainCamera.transform.position = target.position;

                        rotation.value.y -= inputAxis.value.y;
                        rotation.value.y = Mathf.Clamp(rotation.value.y, -60f, 60f);

                        mainCamera.transform.rotation = target.rotation * Quaternion.Euler(rotation.value.y, 0, 0);

                        break;
                    }

                case CameraMode.ThirdPerson:
                    {
                        Vector3 newPosition = target.position - target.forward * 3f;

                        mainCamera.transform.position = newPosition;
                        mainCamera.transform.LookAt(target.position);

                        break;
                    }

                case CameraMode.ThirdPersonFly:
                    {
                        Vector3 newPosition = target.position + target.up * 15f;
                        mainCamera.transform.position = newPosition;
                        mainCamera.transform.LookAt(target.position);
                        break;
                    }
            }

        }
    }
}

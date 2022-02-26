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
        private readonly EcsFilter<CameraComponent, InputAxisComponent, RotationComponent> _cameraFilter = null;
        private readonly SceneData _sceneData = null;

        public void Run()
        {
            if (_cameraFilter.IsEmpty())
                return;

            CinemachineVirtualCamera mainCamera = _sceneData.mainCamera;

            foreach (int i in _cameraFilter)
            {
                ref CameraComponent camera = ref _cameraFilter.Get1(i);
                ref InputAxisComponent inputAxis = ref _cameraFilter.Get2(i);
                ref RotationComponent rotation = ref _cameraFilter.Get3(i);

                Transform target = camera.target;

                switch (camera.mode)
                {
                    case CameraMode.FirstPerson:
                        {
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
}

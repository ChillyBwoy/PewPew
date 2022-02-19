using Cinemachine;
using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components.Camera;
using PewPew.Components.Input;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Camera
{
    sealed class CameraMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraComponent, InputAxisComponent> _cameraFilter = null;
        private readonly EcsFilter<PlayerTag, CameraMountComponent> _playerFilter = null;
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

            switch (camera.mode)
            {
                case CameraMode.FirstPerson:
                    foreach (int i in _playerFilter)
                    {
                        ref CameraMountComponent cameraMount = ref _playerFilter.Get2(i);
                        mainCamera.transform.position = cameraMount.transform.position;
                        mainCamera.transform.rotation = cameraMount.transform.rotation;
                    }
                    break;

                case CameraMode.ThirdPerson:
                    foreach (int i in _playerFilter)
                    {
                        ref CameraMountComponent cameraMount = ref _playerFilter.Get2(i);

                        Vector3 newPosition = cameraMount.transform.position - cameraMount.transform.forward * 3f;
                        Quaternion newAngle = Quaternion.AngleAxis(inputAxis.value.x * Time.deltaTime, Vector3.up);

                        newPosition = newAngle * newPosition;

                        mainCamera.transform.position = Vector3.Slerp(mainCamera.transform.position, newPosition, 0.5f);
                        mainCamera.transform.LookAt(cameraMount.transform.position);
                    }
                    break;

                case CameraMode.ThirdPersonFly:
                    Debug.Log("fly");
                    break;
            }

        }
    }
}

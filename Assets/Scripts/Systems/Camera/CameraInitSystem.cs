using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;
using PewPew.Data;
using PewPew.UnityComponents;

namespace PewPew.Systems
{
    sealed class CameraInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld world = null;
        private readonly SceneData sceneData;

        public void Init()
        {
            EcsEntity entity = world.NewEntity();

            ref var cameraComponent = ref entity.Get<CameraComponent>();
            ref var lookDirectionComponent = ref entity.Get<LookDirectionComponent>();

            lookDirectionComponent.sensitivity = sceneData.lookSensitivity;

            cameraComponent.cameraTransform = sceneData.mainCamera.transform;
            cameraComponent.cameraDistance = sceneData.cameraDistance;
            cameraComponent.cameraFocusRadius = sceneData.cameraFocusRadius;
            cameraComponent.cameraVerticalOffset = sceneData.cameraVerticalOffset;
            cameraComponent.cameraMode = CameraMode.FirstPerson;
        }
    }
}

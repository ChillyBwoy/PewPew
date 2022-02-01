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

            ref var camera = ref entity.Get<CameraComponent>();
            ref var inputAxis = ref entity.Get<InputAxisComponent>();

            camera.cameraTransform = sceneData.mainCamera.transform;
            camera.cameraDistance = sceneData.cameraDistance;
            camera.cameraFocusRadius = sceneData.cameraFocusRadius;
            camera.cameraVerticalOffset = sceneData.cameraVerticalOffset;
            camera.cameraMode = sceneData.cameraMode;
        }
    }
}

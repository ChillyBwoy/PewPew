using Leopotam.Ecs;
using PewPew.Components;
using PewPew.UnityComponents;

namespace PewPew.Systems
{
    sealed class CameraInitSystem : IEcsInitSystem
    {
        private readonly EcsFilter<PlayerComponent, ModelComponent> playerFilter = null;
        private readonly EcsWorld world = null;
        private readonly SceneData sceneData;

        public void Init()
        {
            EcsEntity playerEntity = playerFilter.GetEntity(0);
            var playerModel = playerEntity.Get<ModelComponent>();

            EcsEntity entity = world.NewEntity();

            ref var camera = ref entity.Get<CameraComponent>();
            ref var inputAxis = ref entity.Get<InputAxisComponent>();

            camera.transform = sceneData.mainCamera.transform;
            camera.distance = sceneData.cameraDistance;
            camera.cameraFocusRadius = sceneData.cameraFocusRadius;
            camera.verticalOffset = sceneData.cameraVerticalOffset;
            camera.mode = sceneData.cameraMode;
            // set default target to player
            camera.lookTarget = playerModel.modelTransform;
        }
    }
}

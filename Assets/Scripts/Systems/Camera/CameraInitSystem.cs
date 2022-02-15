using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Camera;
using PewPew.UnityComponents;

namespace PewPew.Systems.Camera
{
    sealed class CameraInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly SceneData _sceneData = null;

        public void Init()
        {
            EcsEntity entity = _world.NewEntity();

            entity.Get<CameraComponent>() = new CameraComponent
            {
                mode = _sceneData.cameraMode
            };
            entity.Get<DirectionComponent>();
            entity.Get<RotationComponent>();
        }
    }
}

using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Camera;
using PewPew.Components.Input;
using PewPew.UnityComponents;

namespace PewPew.Systems.Camera
{
    sealed class CameraInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly SceneData _sceneData = null;
        private readonly EcsFilter<CameraComponent> _filter = null;

        public void Init()
        {
            if (!_filter.IsEmpty())
            {
                return;
            }

            EcsEntity entity = _world.NewEntity();

            entity.Get<CameraComponent>() = new CameraComponent
            {
                mode = _sceneData.cameraMode
            };
            entity.Get<InputAxisComponent>();
        }
    }
}

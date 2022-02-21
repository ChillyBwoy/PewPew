using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Camera;
using PewPew.Components.Events;
using PewPew.Components.Input;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Camera
{
    sealed class CameraInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly SceneData _sceneData = null;
        private readonly EcsFilter<CameraComponent> _cameraFilter = null;
        private readonly EcsFilter<PlayerTag, PlayerSpawnEvent, CameraMountComponent> _playerFilter = null;

        public void Init()
        {
            if (!_cameraFilter.IsEmpty())
                return;

            EcsEntity entity = _world.NewEntity();
            ref CameraMountComponent cameraMount = ref _playerFilter.Get3(0);

            entity.Get<CameraComponent>() = new CameraComponent
            {
                mode = _sceneData.cameraMode,
                target = cameraMount.transform
            };
            entity.Get<InputAxisComponent>();
            entity.Get<RotationComponent>() = new RotationComponent
            {
                value = cameraMount.transform.rotation
            };
        }
    }
}

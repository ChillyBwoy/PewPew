using Leopotam.Ecs;

using PewPew.Components.Camera;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Camera
{
    sealed class CameraUpdateTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraTargetTag, CameraTargetComponent> _filterTarget = null;
        private readonly EcsFilter<CameraComponent> _filterCamera = null;
        private readonly SceneData _sceneData = null;

        public void Run()
        {
            if (_filterTarget.IsEmpty())
                return;

            if (_filterCamera.IsEmpty())
                return;

            ref CameraTargetComponent targetGameObject = ref _filterTarget.Get2(0);

            _filterCamera.GetEntity(0).Get<CameraTargetComponent>() = new CameraTargetComponent
            {
                target = targetGameObject.target
            };
        }
    }
}

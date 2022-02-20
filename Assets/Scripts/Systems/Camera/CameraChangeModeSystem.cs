using Leopotam.Ecs;

using PewPew.Components.Camera;
using PewPew.Components.Events;

namespace PewPew.Systems.Camera
{
    sealed class CameraChangeModeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraComponent, CameraChangeModeEvent> _filter = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref CameraComponent camera = ref _filter.Get1(i);
                ref CameraChangeModeEvent cameraChangeMode = ref _filter.Get2(i);

                camera.mode = cameraChangeMode.mode;
            }
        }
    }
}

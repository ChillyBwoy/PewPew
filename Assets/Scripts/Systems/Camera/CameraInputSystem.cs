using Leopotam.Ecs;

using PewPew.Components.Camera;
using PewPew.Components.Events;
using PewPew.UnityComponents;

namespace PewPew.Systems.Camera
{
    sealed class CameraInputSystem : IEcsRunSystem
    {
        private readonly GameControls _gameControls = null;
        private readonly EcsFilter<CameraComponent> _filter = null;

        public void Run()
        {
            if (!_gameControls.Camera.SwitchMode.triggered)
                return;

            foreach (int i in _filter)
            {
                ref EcsEntity cameraEntity = ref _filter.GetEntity(i);
                ref CameraComponent camera = ref _filter.Get1(i);

                switch (camera.mode)
                {
                    case CameraMode.FirstPerson:
                        cameraEntity.Get<CameraChangeModeEvent>() = new CameraChangeModeEvent
                        {
                            mode = CameraMode.ThirdPerson
                        };
                        break;

                    case CameraMode.ThirdPerson:
                        cameraEntity.Get<CameraChangeModeEvent>() = new CameraChangeModeEvent
                        {
                            mode = CameraMode.ThirdPersonFly
                        };
                        break;

                    case CameraMode.ThirdPersonFly:
                        cameraEntity.Get<CameraChangeModeEvent>() = new CameraChangeModeEvent
                        {
                            mode = CameraMode.FirstPerson
                        };
                        break;
                }
            }
        }
    }
}

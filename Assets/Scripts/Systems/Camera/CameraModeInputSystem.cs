using Leopotam.Ecs;

using PewPew.Components.Camera;
using PewPew.UnityComponents;

namespace PewPew.Systems.Camera
{
    sealed class CameraModeInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraComponent> _filter = null;
        private readonly GameControls _gameControls = null;

        public void Run()
        {
            if (!_gameControls.Camera.SwitchMode.triggered)
                return;

            foreach (int i in _filter)
            {
                ref CameraComponent camera = ref _filter.Get1(i);

                switch (camera.mode)
                {
                    case CameraMode.FirstPerson:
                        camera.mode = CameraMode.SceneMode;
                        break;

                    case CameraMode.SceneMode:
                        camera.mode = CameraMode.FirstPerson;
                        break;
                }
            }
        }
    }
}

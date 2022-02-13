using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components.Camera;
using PewPew.UnityComponents;

namespace PewPew.Systems.Camera
{
    sealed class CameraMoveSystem : IEcsRunSystem
    {
        private readonly SceneData _sceneData = null;
        private readonly EcsFilter<CameraComponent> _filter = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref CameraComponent camera = ref _filter.Get1(i);

                switch (camera.mode)
                {
                    case CameraMode.FirstPerson:
                        break;

                    case CameraMode.SceneMode:
                        break;
                }
            }
        }
    }
}

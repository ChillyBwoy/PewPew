using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;
using PewPew.Data;
using PewPew.UnityComponents;

namespace PewPew.Systems
{
    sealed class CameraMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraComponent, InputAxisComponent> filter = null;
        private readonly SceneData sceneData = null;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref CameraComponent camera = ref filter.Get1(i);
                ref InputAxisComponent inputAxis = ref filter.Get2(i);

                switch (camera.cameraMode)
                {
                    case CameraMode.None:
                        break;

                    case CameraMode.FirstPerson:
                        Quaternion rotateY = Quaternion.AngleAxis(inputAxis.axis.y, Vector3.right * Time.deltaTime * sceneData.lookSensitivity);
                        camera.cameraTransform.rotation = camera.cameraTarget.rotation * rotateY;
                        camera.cameraTransform.localPosition = camera.cameraTarget.position;
                        break;

                    case CameraMode.ThirdPerson:
                        break;

                    case CameraMode.FlyMode:
                        break;
                }
            }
        }
    }
}

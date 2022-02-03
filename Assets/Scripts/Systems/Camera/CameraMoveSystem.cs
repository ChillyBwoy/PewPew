using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;
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

                switch (camera.mode)
                {
                    case CameraMode.FirstPerson:
                        FirstPersonMode(camera, inputAxis);
                        break;

                    case CameraMode.ThirdPerson:
                        ThirdPersonMode(camera, inputAxis);
                        break;

                    case CameraMode.FlyMode:
                        FlyMode(camera, inputAxis);
                        break;

                    case CameraMode.Arena:
                        ArenaMode(camera, inputAxis);
                        break;
                }
            }
        }

        private void ThirdPersonMode(CameraComponent camera, InputAxisComponent inputAxis)
        {
            Vector3 targetPos = camera.lookTarget.position;
            Vector2 orbitAngles = new Vector2(45f, 0f);
            Quaternion lookRotation = Quaternion.Euler(orbitAngles);

            Vector3 lookDirection = lookRotation * Vector3.forward;
            Vector3 lookPosition = targetPos - lookDirection * camera.distance;

            camera.transform.SetPositionAndRotation(lookPosition, lookRotation);
        }

        private void ArenaMode(CameraComponent camera, InputAxisComponent inputAxis)
        {
            Vector3 targetPos = camera.lookTarget.position;
            camera.transform.forward = Vector3.down;
            camera.transform.position = new Vector3(0, 15f, 0);
            camera.transform.LookAt(targetPos);
        }

        private void FlyMode(CameraComponent camera, InputAxisComponent inputAxis)
        {
            Vector3 targetPos = camera.lookTarget.position;
            camera.transform.forward = Vector3.down;
            camera.transform.position = new Vector3(targetPos.x, 15f, targetPos.z);
        }

        private void FirstPersonMode(CameraComponent camera, InputAxisComponent inputAxis)
        {
            Quaternion rotateY = Quaternion.AngleAxis(inputAxis.axis.y, Vector3.right * sceneData.lookSensitivity * Time.deltaTime);
            camera.transform.rotation = camera.lookTarget.rotation * rotateY;
            camera.transform.position = camera.lookTarget.position;
        }
    }
}

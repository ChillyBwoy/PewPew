using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{
    sealed class PlayerCameraSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<PlayerComponent, CameraComponent, ModelComponent> filter = null;

        private Vector3 focusPoint;

        private Vector3 WithVerticalOffset(Vector3 pos, float offset)
        {
            return new Vector3(pos.x, pos.y + offset, pos.z);
        }

        public void Init()
        {
            foreach (var i in filter)
            {
                ref var playerComponent = ref filter.Get1(i);
                ref var cameraComponent = ref filter.Get2(i);

                focusPoint = WithVerticalOffset(playerComponent.lookAt.transform.position, cameraComponent.cameraVerticalOffset);
            }
        }

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var playerComponent = ref filter.Get1(i);
                ref var cameraComponent = ref filter.Get2(i);
                ref var modelComponent = ref filter.Get3(i);

                switch (cameraComponent.cameraState)
                {
                    case CameraComponent.CameraState.FirstPerson:
                        cameraComponent.cameraTransform.localPosition = modelComponent.modelTransform.position;
                        break;

                    case CameraComponent.CameraState.ThirdPerson:
                        var target = playerComponent.lookAt.transform;
                        var focusRadius = cameraComponent.cameraFocusRadius;
                        var verticalOffset = cameraComponent.cameraVerticalOffset;

                        if (focusRadius > 0f)
                        {
                            float distance = Vector3.Distance(target.position, focusPoint);
                            if (distance > focusRadius)
                            {
                                focusPoint = Vector3.Lerp(target.position, focusPoint, focusRadius / distance);
                            }
                        }
                        else
                        {
                            focusPoint = WithVerticalOffset(target.position, verticalOffset);
                        }

                        Vector3 lookDirection = target.forward;
                        cameraComponent.cameraTransform.localPosition = focusPoint - lookDirection * cameraComponent.cameraDistance;
                        break;
                }
            }
        }
    }
}

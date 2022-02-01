using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;
using PewPew.Data;

namespace PewPew.Systems
{
    sealed class CameraMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, ModelComponent, CameraComponent> filter = null;

        private Vector3 WithVerticalOffset(Vector3 pos, float offset)
        {
            return new Vector3(pos.x, pos.y + offset, pos.z);
        }

        public void Run()
        {
            foreach (var i in filter)
            {
                ref ModelComponent modelComponent = ref filter.Get2(i);
                ref CameraComponent cameraComponent = ref filter.Get3(i);

                switch (cameraComponent.cameraMode)
                {
                    case CameraMode.FirstPerson:
                        cameraComponent.cameraTransform.localPosition = modelComponent.modelTransform.position;
                        break;

                    case CameraMode.ThirdPerson:
                        Transform target = modelComponent.modelTransform.transform;
                        float focusRadius = cameraComponent.cameraFocusRadius;
                        float verticalOffset = cameraComponent.cameraVerticalOffset;
                        Vector3 focusPoint = WithVerticalOffset(modelComponent.modelTransform.position, cameraComponent.cameraVerticalOffset);

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

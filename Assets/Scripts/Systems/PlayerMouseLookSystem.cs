using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{

    sealed class PlayerMouseLookSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, ModelComponent> playerFilter = null;
        private readonly EcsFilter<PlayerComponent, ModelComponent, MouseLookDirectionComponent, CameraComponent> mouseLookFilter = null;
        private Quaternion startTransformRotation;

        public void Init()
        {
            foreach (var i in playerFilter)
            {
                ref EcsEntity entity = ref playerFilter.GetEntity(i);
                ref ModelComponent model = ref playerFilter.Get2(i);

                startTransformRotation = model.modelTransform.rotation;
            }
        }

        public void Run()
        {
            foreach (var i in mouseLookFilter)
            {
                ref ModelComponent modelComponent = ref mouseLookFilter.Get2(i);
                ref MouseLookDirectionComponent lookComponent = ref mouseLookFilter.Get3(i);
                ref CameraComponent cameraComponent = ref mouseLookFilter.Get4(i);

                float axisX = lookComponent.direction.x;
                float axisY = lookComponent.direction.y;

                Quaternion rotateX = Quaternion.AngleAxis(axisX, Vector3.up * Time.deltaTime * lookComponent.mouseSensitivity);
                Quaternion rotateY = Quaternion.AngleAxis(axisY, Vector3.right * Time.deltaTime * lookComponent.mouseSensitivity);

                modelComponent.modelTransform.rotation = startTransformRotation * rotateX;
                cameraComponent.cameraTransform.rotation = modelComponent.modelTransform.rotation * rotateY;
            }
        }
    }
}

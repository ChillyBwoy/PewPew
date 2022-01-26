using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{

    sealed class PlayerMouseLookSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent> playerFilter = null;
        private readonly EcsFilter<PlayerComponent, ModelComponent, MouseLookDirectionComponent, CameraComponent> mouseLookFilter = null;
        private Quaternion startTransformRotation;

        public void Init()
        {
            foreach (var i in playerFilter)
            {
                ref var entity = ref playerFilter.GetEntity(i);
                ref var model = ref entity.Get<ModelComponent>();
                startTransformRotation = model.modelTransform.rotation;
            }
        }

        public void Run()
        {
            foreach (var i in mouseLookFilter)
            {
                ref var modelComponent = ref mouseLookFilter.Get2(i);
                ref var lookComponent = ref mouseLookFilter.Get3(i);
                ref var cameraComponent = ref mouseLookFilter.Get4(i);

                var axisX = lookComponent.direction.x;
                var axisY = lookComponent.direction.y;

                var rotateX = Quaternion.AngleAxis(axisX, Vector3.up * Time.deltaTime * lookComponent.mouseSensitivity);
                var rotateY = Quaternion.AngleAxis(axisY, Vector3.right * Time.deltaTime * lookComponent.mouseSensitivity);

                modelComponent.modelTransform.rotation = startTransformRotation * rotateX;
                cameraComponent.cameraTransform.rotation = modelComponent.modelTransform.rotation * rotateY;
            }
        }
    }
}
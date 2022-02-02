using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;
using PewPew.UnityComponents;

namespace PewPew.Systems
{
    sealed class PlayerMouseLookSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly SceneData sceneData = null;
        private readonly EcsFilter<PlayerComponent, ModelComponent> playerFilter = null;
        private readonly EcsFilter<PlayerComponent, ModelComponent, InputAxisComponent> mouseLookFilter = null;
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
                ref ModelComponent model = ref mouseLookFilter.Get2(i);
                ref InputAxisComponent inputAxis = ref mouseLookFilter.Get3(i);

                float axisX = inputAxis.axis.x;
                float axisY = inputAxis.axis.y;

                Quaternion rotateX = Quaternion.AngleAxis(axisX, Vector3.up * Time.deltaTime * sceneData.lookSensitivity);
                model.modelTransform.rotation = startTransformRotation * rotateX;
            }
        }
    }
}

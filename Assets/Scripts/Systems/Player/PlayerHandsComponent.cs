using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Input;
using PewPew.Components.Tags;

namespace PewPew.Systems.Player
{
    sealed class PlayerHandsComponent : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, InputAxisComponent, HandsComponent> _filter = null;

        private void ApplyVerticalRotation(Vector2 axis, Transform transform)
        {
            Quaternion rotationBy = transform.rotation;
            rotationBy.y = axis.y;
            rotationBy.y = Mathf.Clamp(rotationBy.y, -60f, 60f);
            transform.rotation = transform.rotation * Quaternion.Euler(-rotationBy.y, 0, 0);
        }

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref InputAxisComponent inputAxis = ref _filter.Get2(i);
                ref HandsComponent hands = ref _filter.Get3(i);

                ApplyVerticalRotation(inputAxis.value, hands.rightHand.transform);
                ApplyVerticalRotation(inputAxis.value, hands.leftHand.transform);
            }
        }
    }
}

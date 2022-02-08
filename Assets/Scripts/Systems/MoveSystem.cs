using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;
using PewPew.Components.Physics;
using PewPew.UnityComponents;

namespace PewPew.Systems
{
    sealed class MoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<RigidbodyComponent, DirectionComponent, VelocityComponent> _filter = null;
        private readonly StaticData _staticData = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref RigidbodyComponent rigidBody = ref _filter.Get1(i);
                ref DirectionComponent position = ref _filter.Get2(i);
                ref VelocityComponent velocity = ref _filter.Get3(i);

                Vector3 offset = position.value.normalized * _staticData.playerSpeed * Time.deltaTime;

                rigidBody.value.MovePosition(rigidBody.value.position + offset);
                rigidBody.value.AddForce(velocity.value, ForceMode.VelocityChange);

                velocity.value = Vector3.zero;
            }
        }
    }
}

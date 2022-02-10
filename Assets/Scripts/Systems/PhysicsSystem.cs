using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.UnityComponents;

namespace PewPew.Systems
{
    sealed class PhysicsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterComponent, VelocityComponent> _filter = null;
        private readonly StaticData _staticData = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref CharacterComponent character = ref _filter.Get1(i);
                ref VelocityComponent velocity = ref _filter.Get2(i);
                ref Rigidbody rigidbody = ref character.rigidbody;

                // if (!character.isGrounded)
                // {
                //     velocity.value.y += _staticData.gravity.y * Time.deltaTime;
                // }

                rigidbody.AddForce(velocity.value, ForceMode.Impulse);
                velocity.value = Vector3.zero;
            }
        }
    }
}

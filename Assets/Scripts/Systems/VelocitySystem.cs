using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;

namespace PewPew.Systems
{
    sealed class VelocitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterComponent, VelocityComponent> _filter = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref CharacterComponent character = ref _filter.Get1(i);
                ref VelocityComponent velocity = ref _filter.Get2(i);

                if (velocity.value != Vector3.zero)
                {
                    character.rigidbody.AddForce(velocity.value, ForceMode.Impulse);
                    velocity.value = Vector3.zero;
                }
            }
        }
    }
}

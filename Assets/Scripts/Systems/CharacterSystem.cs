using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;

namespace PewPew.Systems
{
    sealed class CharacterSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterComponent> _filter = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref CharacterComponent character = ref _filter.Get1(i);
                ref Rigidbody rigidbody = ref character.rigidbody;

                character.isGrounded = Physics.Raycast(
                    rigidbody.transform.position,
                    Vector3.down,
                    0.1f
                );
            }
        }
    }
}

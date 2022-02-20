using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;

namespace PewPew.Systems
{
    sealed class MoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterComponent, DirectionComponent> _filter = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref CharacterComponent character = ref _filter.Get1(i);
                ref DirectionComponent direction = ref _filter.Get2(i);


                if (character.rigidbody.isKinematic)
                {
                    Transform transform = character.rigidbody.transform;
                    character.rigidbody.MovePosition(transform.position + direction.value);
                }
                else
                {
                    character.rigidbody.AddForce(direction.value, ForceMode.Force);
                }
            }
        }
    }
}

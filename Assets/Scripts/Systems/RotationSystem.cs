using Leopotam.Ecs;

using PewPew.Components;

namespace PewPew.Systems
{
    sealed class RotationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterComponent, RotationComponent> _filter = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref CharacterComponent character = ref _filter.Get1(i);
                ref RotationComponent rotation = ref _filter.Get2(i);

                character.rigidbody.MoveRotation(rotation.value);
            }
        }
    }
}

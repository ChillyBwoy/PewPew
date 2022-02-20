using Leopotam.Ecs;

using PewPew.Components.Common;
using PewPew.Components;

namespace PewPew.Systems
{
    sealed class RotationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GameObjectComponent, CharacterComponent, RotationComponent> _filter = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref GameObjectComponent gameObject = ref _filter.Get1(i);
                ref CharacterComponent character = ref _filter.Get2(i);
                ref RotationComponent rotation = ref _filter.Get3(i);

                gameObject.value.transform.rotation *= rotation.value;
            }
        }
    }
}

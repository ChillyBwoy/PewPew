using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;

namespace PewPew.Systems
{
    sealed class MoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GameObjectComponent, CharacterComponent, DirectionComponent> _filter = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref GameObjectComponent gameObject = ref _filter.Get1(i);
                ref CharacterComponent character = ref _filter.Get2(i);
                ref DirectionComponent direction = ref _filter.Get3(i);

                character.rigidbody.MovePosition(gameObject.value.transform.position + direction.value);
            }
        }
    }
}

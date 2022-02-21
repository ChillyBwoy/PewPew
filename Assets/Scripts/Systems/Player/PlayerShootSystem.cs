using Leopotam.Ecs;

using PewPew.Components.Events;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Player
{
    sealed class PlayerShootSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag> _filter = null;
        private readonly GameControls _gameControls = null;

        public void Run()
        {
            if (!_gameControls.Player.Shoot.triggered)
                return;

            foreach (int i in _filter)
            {
                EcsEntity entity = _filter.GetEntity(i);
                entity.Get<ShootEvent>();
            }
        }
    }
}

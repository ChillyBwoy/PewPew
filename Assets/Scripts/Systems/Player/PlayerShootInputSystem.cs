using Leopotam.Ecs;
using PewPew.Components;
using PewPew.UnityComponents;

namespace PewPew.Systems
{
    sealed class PlayerShootInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent> playerFilter = null;
        private readonly GameControls gameControls = null;
        public void Run()
        {
            if (!gameControls.Player.Shoot.triggered)
                return;

            foreach (var i in playerFilter)
            {
                ref var entity = ref playerFilter.GetEntity(i);
                entity.Get<ShootEvent>();
            }
        }
    }
}

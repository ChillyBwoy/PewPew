using Leopotam.Ecs;
using PewPew.Components;
using PewPew.UnityComponents;

namespace PewPew.Systems
{
    sealed class PlayerJumpInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, JumpComponent> playerFilter = null;
        private readonly GameControls gameControls = null;

        public void Run()
        {
            if (!gameControls.Player.Jump.triggered)
                return;

            foreach (var i in playerFilter)
            {
                ref var entity = ref playerFilter.GetEntity(i);
                entity.Get<JumpEvent>();
            }
        }
    }
}

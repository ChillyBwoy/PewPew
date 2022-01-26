using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{
    sealed class PlayerJumpSendEventSystem : IEcsRunSystem
    {

        private readonly EcsFilter<PlayerComponent, JumpComponent> playerFilter = null;
        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            foreach (var i in playerFilter)
            {
                ref var entity = ref playerFilter.GetEntity(i);
                entity.Get<JumpEvent>();
            }
        }
    }
}
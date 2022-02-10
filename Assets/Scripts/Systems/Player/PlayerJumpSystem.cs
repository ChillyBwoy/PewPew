using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;
using PewPew.Components.Events;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Player
{
    sealed class PlayerJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, GameObjectComponent, VelocityComponent, JumpEvent> _filter = null;

        private readonly StaticData _staticData = null;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref GameObjectComponent gameObject = ref _filter.Get2(i);
                ref VelocityComponent velocity = ref _filter.Get3(i);
                ref JumpEvent jump = ref _filter.Get4(i);

                velocity.value.y = jump.force;
            }
        }
    }
}

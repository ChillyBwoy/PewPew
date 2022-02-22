using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Events;
using PewPew.Components.Tags;

namespace PewPew.Systems.Player
{
    sealed class PlayerPowerUpPickSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, PowerUpPickUpEvent, MountingComponent> _filter = null;
        public void Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            foreach (int i in _filter)
            {
                ref PowerUpPickUpEvent powerUpPickUp = ref _filter.Get2(i);
                ref MountingComponent mounting = ref _filter.Get3(i);

                // mounting.mountingPoint

                EcsEntity targetEntity = powerUpPickUp.targetEntity;
            }
        }
    }
}

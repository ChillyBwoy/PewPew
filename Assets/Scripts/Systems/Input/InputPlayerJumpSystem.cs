using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Tags;
using PewPew.Components.Events;
using PewPew.UnityComponents;

namespace PewPew.Systems.Input
{
    sealed class InputPlayerJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, CharacterComponent> _filter = null;
        private readonly GameControls _gameControls = null;
        private readonly StaticData _staticData = null;

        public void Run()
        {
            if (!_gameControls.Player.Jump.triggered)
                return;

            foreach (var i in _filter)
            {
                ref CharacterComponent character = ref _filter.Get2(i);
                ref Rigidbody rigidBody = ref character.rigidbody;

                if (character.isGrounded)
                {
                    ref EcsEntity entity = ref _filter.GetEntity(i);
                    float jumpForce = 2 * Mathf.Pow(_staticData.gravity.y, 2);

                    entity.Get<JumpEvent>() = new JumpEvent
                    {
                        force = jumpForce
                    };
                }
            }
        }
    }
}

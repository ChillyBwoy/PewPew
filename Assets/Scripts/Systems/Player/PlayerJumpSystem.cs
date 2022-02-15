using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Player
{
    sealed class PlayerJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, CharacterComponent, VelocityComponent> _filter = null;
        private readonly GameControls _gameControls = null;
        private readonly StaticData _staticData = null;

        private bool isGrounded(Collider collider)
        {
            float distToGround = collider.bounds.extents.y;

            return Physics.Raycast(collider.bounds.center, Vector3.down, distToGround + 0.1f);
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref CharacterComponent character = ref _filter.Get2(i);
                ref VelocityComponent velocity = ref _filter.Get3(i);

                if (_gameControls.Player.Jump.triggered)
                {
                    if (isGrounded(character.collider))
                    {
                        velocity.value = _staticData.jumpForce * Vector3.up;
                    }
                }
            }
        }
    }
}

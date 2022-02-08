using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components.Physics;
using PewPew.Components.Tags;
using PewPew.Components.Events;
using PewPew.UnityComponents;

namespace PewPew.Systems.Input
{
    sealed class InputPlayerJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, RigidbodyComponent, CapsuleColliderComponent> _filter = null;
        private readonly GameControls _gameControls = null;
        private readonly StaticData _staticData = null;

        public void Run()
        {
            if (!_gameControls.Player.Jump.triggered)
                return;

            foreach (var i in _filter)
            {
                ref RigidbodyComponent rigidBody = ref _filter.Get2(i);
                ref CapsuleColliderComponent collider = ref _filter.Get3(i);

                bool isGrounded = Physics.Raycast(
                    rigidBody.value.transform.position,
                    Vector3.down,
                    collider.value.height / 2 + 0.1f
                );

                if (isGrounded)
                {
                    ref EcsEntity entity = ref _filter.GetEntity(i);
                    entity.Get<JumpEvent>() = new JumpEvent
                    {
                        force = _staticData.jumpForce,
                        cooldown = _staticData.jumpCooldown
                    };
                }
            }
        }
    }
}

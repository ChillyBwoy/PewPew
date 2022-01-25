using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{

    sealed class PlayerJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, GroundCheckSphereComponent, JumpComponent, JumpEvent>.Exclude<BlockJumpDurationComponent> jumpFilter = null;
        public void Run()
        {
            foreach (var i in jumpFilter)
            {
                ref var entity = ref jumpFilter.GetEntity(i);
                ref var groundCheck = ref jumpFilter.Get2(i);
                ref var jumpComponent = ref jumpFilter.Get3(i);
                ref var movable = ref entity.Get<MovableComponent>();
                ref var velocity = ref movable.velocity;

                if (!groundCheck.isGrounded) continue;

                velocity.y = Mathf.Sqrt(jumpComponent.jumpForce * -2f * movable.gravity);
                entity.Get<BlockJumpDurationComponent>().timer = jumpComponent.jumpCooldown;
            }
        }
    }
}
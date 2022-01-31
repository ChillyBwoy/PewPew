using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{
    sealed class JumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GroundCheckSphereComponent, JumpComponent, MovableComponent, JumpEvent>.Exclude<BlockJumpDurationComponent> jumpFilter = null;
        public void Run()
        {
            foreach (var i in jumpFilter)
            {
                ref EcsEntity entity = ref jumpFilter.GetEntity(i);

                ref GroundCheckSphereComponent groundCheck = ref jumpFilter.Get1(i);
                ref JumpComponent jumpComponent = ref jumpFilter.Get2(i);
                ref MovableComponent movable = ref jumpFilter.Get3(i);

                ref var velocity = ref movable.velocity;

                if (!groundCheck.isGrounded) continue;

                velocity.y = Mathf.Sqrt(jumpComponent.jumpForce * -2f * movable.gravity);
                entity.Get<BlockJumpDurationComponent>().timer = jumpComponent.jumpCooldown;
            }
        }
    }
}
using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{
    sealed class PlayerGroundCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, GroundCheckSphereComponent> groundFilter = null;
        public void Run()
        {
            foreach (var i in groundFilter)
            {
                ref var groundCheck = ref groundFilter.Get2(i);
                groundCheck.isGrounded = Physics.CheckSphere(
                    groundCheck.groundCheckSphere.position,
                    groundCheck.groundDistance,
                    groundCheck.groundMask);
            }
        }
    }
}
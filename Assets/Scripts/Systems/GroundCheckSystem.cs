using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{
    sealed class GroundCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GroundCheckSphereComponent> groundFilter = null;
        public void Run()
        {
            foreach (var i in groundFilter)
            {
                ref GroundCheckSphereComponent groundCheck = ref groundFilter.Get1(i);

                groundCheck.isGrounded = Physics.CheckSphere(
                    groundCheck.groundCheckSphere.position,
                    groundCheck.groundDistance,
                    groundCheck.groundMask);
            }
        }
    }
}
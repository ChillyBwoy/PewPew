using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{
    sealed class JumpBlockSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BlockJumpDurationComponent> blockFilter = null;
        public void Run()
        {
            foreach (var i in blockFilter)
            {
                ref EcsEntity entity = ref blockFilter.GetEntity(i);
                ref BlockJumpDurationComponent block = ref blockFilter.Get1(i);

                block.timer -= Time.deltaTime;
                if (block.timer <= 0)
                {
                    entity.Del<BlockJumpDurationComponent>();
                }
            }
        }
    }
}
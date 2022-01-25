using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{
    sealed class DebugSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DebugMessageRequestComponent> messageFilter = null;
        public void Run()
        {
            foreach (var i in messageFilter)
            {
                ref var entity = ref messageFilter.GetEntity(i);
                ref var request = ref messageFilter.Get1(i);
                ref var message = ref request.message;

                Debug.Log(message);
                entity.Del<DebugMessageRequestComponent>();
            }
        }
    }
}

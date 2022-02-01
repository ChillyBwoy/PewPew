using Leopotam.Ecs;

namespace PewPew.Extensions
{
    public static class WorldExtension
    {
        public static void SendMessage<T>(this EcsWorld world, in T messageEvent) where T : struct
        {
            ref var component = ref world.NewEntity().Get<T>();
            component = messageEvent;
        }
    }
}

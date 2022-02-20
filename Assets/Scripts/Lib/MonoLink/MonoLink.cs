using Leopotam.Ecs;

namespace PewPew.Lib.MonoLink
{
    public class MonoLink<T> : MonoLinkBase where T : struct
    {
        public T properties;

        public override void Make(ref EcsEntity entity)
        {
            if (entity.Has<T>())
            {
                return;
            }

            entity.Get<T>() = properties;
        }
    }
}

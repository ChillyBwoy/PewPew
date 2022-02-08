using Leopotam.Ecs;

using PewPew.Lib.MonoLink;
using PewPew.Components.Common;

namespace PewPew.UnityComponents.MonoLinks
{
    public class GameObjectMonoLink : MonoLink<GameObjectComponent>
    {
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<GameObjectComponent>() = new GameObjectComponent { value = gameObject };
        }
    }
}

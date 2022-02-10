using Leopotam.Ecs;
using PewPew.Components.Common;
using PewPew.Lib.MonoLink;

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

using UnityEngine;
using Leopotam.Ecs;

namespace PewPew.Lib.MonoLink
{
    public abstract class MonoEntity : MonoLinkBase
    {
        protected EcsEntity _entity;
        protected MonoLinkBase[] _monoLinks;

        public MonoLink<T> GetMonoLink<T>() where T : struct
        {
            foreach (MonoLinkBase link in _monoLinks)
            {
                if (link is MonoLink<T> monoLink)
                {
                    return monoLink;
                }
            }

            return null;
        }

        public bool Has<T>() where T : struct
        {
            return _entity.Has<T>();
        }

        public override void Make(ref EcsEntity entity)
        {
            _entity = entity;
            _monoLinks = GetComponents<MonoLinkBase>();

            foreach (MonoLinkBase monoLink in _monoLinks)
            {
                if (monoLink is MonoEntity)
                {
                    continue;
                }
                monoLink.Make(ref entity);
            }
        }

        private void OnDestroy()
        {
            if (_entity.IsAlive())
            {
                _entity.Destroy();
            }
        }
    }
}

using Leopotam.Ecs;
using UnityEngine;

namespace PewPew.Lib.MonoLink
{
    [RequireComponent(typeof(MonoEntity))]
    public abstract class MonoLinkBase : MonoBehaviour
    {
        public abstract void Make(ref EcsEntity entity);
    }
}

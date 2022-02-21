using Leopotam.Ecs;
using UnityEngine;

namespace PewPew.Lib.MonoLink
{
    public abstract class MonoLinkBase : MonoBehaviour
    {
        public abstract void Make(ref EcsEntity entity);
    }
}

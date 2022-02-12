using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components.Common;
using PewPew.Lib.MonoLink;

namespace PewPew.Lib.Factories
{
    public class PrefabFactory : MonoBehaviour
    {
        public void Spawn(ref EcsEntity entity, SpawnComponent spawnComponent)
        {
            GameObject gameObject = Instantiate(
                spawnComponent.prefab,
                spawnComponent.position,
                spawnComponent.rotation,
                spawnComponent.parent
            );

            var monoEntity = gameObject.GetComponent<MonoEntity>();
            if (monoEntity == null)
                return;

            monoEntity.Make(ref entity);
        }
    }
}

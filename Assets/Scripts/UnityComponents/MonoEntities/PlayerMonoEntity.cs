using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components.Tags;
using PewPew.Lib.MonoLink;

namespace PewPew.UnityComponents.MonoEntities
{
    public class PlayerMonoEntity : MonoEntity
    {
        private void OnCollisionEnter(Collision other)
        {
            MonoEntity entity = other.gameObject.GetComponent<MonoEntity>();
            if (entity == null)
            {
                return;
            }

            if (entity.Has<PowerUpTag>())
            {
                Destroy(other.gameObject);
            }
        }
    }
}

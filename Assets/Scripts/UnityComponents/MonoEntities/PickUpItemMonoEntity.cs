using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Events;
using PewPew.Lib.MonoLink;

namespace PewPew.UnityComponents.MonoEntities
{
    public class PickUpItemMonoEntity : MonoEntity
    {
        private void OnCollisionEnter(Collision other)
        {
            MonoEntity otherEntity = other.gameObject.GetComponent<MonoEntity>();

            if (otherEntity == null)
            {
                return;
            }

            if (otherEntity.Has<CharacterComponent>())
            {
                otherEntity.entity.Get<PickUpEvent>() = new PickUpEvent
                {
                    targetEntity = entity
                };
            }
        }
    }
}

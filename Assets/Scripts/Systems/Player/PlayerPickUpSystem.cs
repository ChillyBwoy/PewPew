using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;
using PewPew.Components.Events;
using PewPew.Components.Tags;

namespace PewPew.Systems.Player
{
    sealed class PlayerPickUpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, PickUpEvent, HandsComponent, InventoryComponent> _filter = null;
        public void Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            foreach (int i in _filter)
            {
                ref EcsEntity playerEntity = ref _filter.GetEntity(i);
                ref PickUpEvent powerUpPickUp = ref _filter.Get2(i);
                ref HandsComponent hands = ref _filter.Get3(i);
                ref InventoryComponent inventory = ref _filter.Get4(i);

                EcsEntity targetEntity = powerUpPickUp.targetEntity;
                if (!targetEntity.Has<GameObjectComponent>())
                {
                    continue;
                }

                ref GameObjectComponent targetGameObject = ref targetEntity.Get<GameObjectComponent>();

                inventory.items.ForEach(delegate (InventoryItemComponent item)
                {
                    item.isActive = false;
                });

                inventory.items.Add(new InventoryItemComponent
                {
                    entity = targetEntity,
                    isActive = true
                });

                var rb = targetGameObject.value.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                rb.useGravity = false;

                targetGameObject.value.transform.SetParent(hands.rightHand);
                targetGameObject.value.transform.localPosition = Vector3.zero;
                targetGameObject.value.transform.localRotation = Quaternion.identity;
            }
        }
    }
}

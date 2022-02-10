using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;
using PewPew.Components.Input;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Player
{
    sealed class PlayerMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, GameObjectComponent, DirectionComponent, InputDirectionComponent> _filter = null;
        private readonly StaticData _staticData = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref GameObjectComponent gameObject = ref _filter.Get2(i);
                ref DirectionComponent direction = ref _filter.Get3(i);
                ref InputDirectionComponent inputDirection = ref _filter.Get4(i);

                Transform transform = gameObject.value.transform;

                Vector3 moveBy = transform.right * inputDirection.value.x + transform.forward * inputDirection.value.z;
                direction.value = moveBy.normalized * _staticData.playerSpeed * Time.deltaTime;
            }
        }
    }
}

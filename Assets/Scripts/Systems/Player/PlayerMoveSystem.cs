using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Player
{
    sealed class PlayerMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, GameObjectComponent, DirectionComponent> _filter = null;
        private readonly GameControls _gameControls = null;
        private readonly StaticData _staticData = null;

        public void Run()
        {
            var moveInput = _gameControls.Player.Move.ReadValue<Vector2>();

            foreach (var i in _filter)
            {
                ref GameObjectComponent gameObject = ref _filter.Get2(i);
                ref DirectionComponent direction = ref _filter.Get3(i);

                Transform transform = gameObject.value.transform;

                Vector3 moveDirection = (transform.forward * moveInput.y) + (transform.right * moveInput.x);

                direction.value = moveDirection.normalized * _staticData.playerSpeed;
            }
        }
    }
}

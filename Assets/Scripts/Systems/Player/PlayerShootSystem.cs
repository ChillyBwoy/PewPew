using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Player
{
    sealed class PlayerShootSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, InventoryComponent> _filter = null;
        private readonly GameControls _gameControls = null;
        private readonly EcsWorld _world = null;

        public void Run()
        {
            if (!_gameControls.Player.Shoot.triggered)
                return;

            foreach (int i in _filter)
            {
                ref InventoryComponent inventory = ref _filter.Get2(i);

                int matchedIndex = inventory.items.FindIndex(item => item.isActive);

                if (matchedIndex == -1)
                {
                    continue;
                }

                InventoryItemComponent activeWeapon = inventory.items[matchedIndex];
                EcsEntity weaponEntity = activeWeapon.entity;

                if (weaponEntity.Has<ProjectileSpawnerComponent>())
                {
                    ref ProjectileSpawnerComponent spawner = ref weaponEntity.Get<ProjectileSpawnerComponent>();

                    EcsEntity projectileEntity = _world.NewEntity();
                    projectileEntity.Get<SpawnComponent>() = new SpawnComponent
                    {
                        prefab = spawner.prefab,
                        position = spawner.spawnPoint.position,
                        rotation = spawner.spawnPoint.rotation,
                        parent = null,
                    };
                    projectileEntity.Get<VelocityComponent>() = new VelocityComponent
                    {
                        value = spawner.spawnPoint.forward * 50f
                    };
                }
            }
        }
    }
}

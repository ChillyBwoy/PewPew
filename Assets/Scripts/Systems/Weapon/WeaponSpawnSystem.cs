using System.Linq;
using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;
using PewPew.Components.Events;
using PewPew.Components.Input;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Weapon
{
    sealed class WeaponSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly StaticData _staticData = null;
        private readonly SceneData _sceneData = null;
        private readonly EcsFilter<WeaponSpawnEvent> _filter = null;
        private int _nextIndex = 0;
        private int nextIndex
        {
            get
            {
                int index = _nextIndex;
                _nextIndex++;

                if (_nextIndex >= _sceneData.weapons.Length)
                {
                    _nextIndex = 0;
                }

                return index;
            }
        }

        private void InitializeAt(int index)
        {
            WeaponData weaponData = _sceneData.weapons[index];

            EcsEntity entity = _world.NewEntity();

            entity.Get<SpawnComponent>() = new SpawnComponent
            {
                prefab = weaponData.weaponPrefab,
                position = weaponData.transform.position,
                rotation = weaponData.transform.rotation,
                parent = null,
            };
            entity.Get<WeaponTag>();
            entity.Get<PowerUpTag>();
            entity.Get<RotationComponent>() = new RotationComponent { value = weaponData.transform.rotation };
            entity.Get<InputAxisComponent>();
        }

        public void Init()
        {
            for (int i = 0; i < _sceneData.weapons.Length; i++)
            {
                InitializeAt(i);
            }
        }

        public void Run()
        {
            if (_filter.IsEmpty())
                return;

            InitializeAt(nextIndex);
        }
    }
}

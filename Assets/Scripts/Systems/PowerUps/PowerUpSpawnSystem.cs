using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;
using PewPew.Components.Events;
using PewPew.Components.Input;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.PowerUps
{
    sealed class PowerUpSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly StaticData _staticData = null;
        private readonly SceneData _sceneData = null;
        private readonly EcsFilter<PowerUpSpawnEvent> _filter = null;
        private int _nextIndex = 0;
        private int nextIndex
        {
            get
            {
                int index = _nextIndex;
                _nextIndex++;

                if (_nextIndex >= _sceneData.powerUps.Length)
                {
                    _nextIndex = 0;
                }

                return index;
            }
        }

        private void InitializeAt(int index)
        {
            PowerUpData powerUpData = _sceneData.powerUps[index];

            EcsEntity entity = _world.NewEntity();

            entity.Get<SpawnComponent>() = new SpawnComponent
            {
                prefab = powerUpData.prefab,
                position = powerUpData.transform.position,
                rotation = powerUpData.transform.rotation,
                parent = null,
            };
            entity.Get<RotationComponent>() = new RotationComponent { value = powerUpData.transform.rotation };
            entity.Get<InputAxisComponent>();
        }

        public void Init()
        {
            for (int i = 0; i < _sceneData.powerUps.Length; i++)
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

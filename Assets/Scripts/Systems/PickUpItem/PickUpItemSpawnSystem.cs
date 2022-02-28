using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Common;
using PewPew.Components.Events;
using PewPew.Components.Input;
using PewPew.UnityComponents;

namespace PewPew.Systems.PickUpItem
{
    sealed class PickUpItemSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly StaticData _staticData = null;
        private readonly SceneData _sceneData = null;
        private readonly EcsFilter<PickUpItemSpawnEvent> _filter = null;
        private int _nextIndex = 0;
        private int nextIndex
        {
            get
            {
                int index = _nextIndex;
                _nextIndex++;

                if (_nextIndex >= _sceneData.pickUpItems.Length)
                {
                    _nextIndex = 0;
                }

                return index;
            }
        }

        private void InitializeAt(int index)
        {
            PickUpItemData pickUpItemData = _sceneData.pickUpItems[index];

            EcsEntity entity = _world.NewEntity();

            entity.Get<SpawnComponent>() = new SpawnComponent
            {
                prefab = pickUpItemData.prefab,
                position = pickUpItemData.transform.position,
                rotation = pickUpItemData.transform.rotation,
                parent = null,
            };
            entity.Get<RotationComponent>() = new RotationComponent { value = pickUpItemData.transform.rotation };
            entity.Get<InputAxisComponent>();
        }

        public void Init()
        {
            for (int i = 0; i < _sceneData.pickUpItems.Length; i++)
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

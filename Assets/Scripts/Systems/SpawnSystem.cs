using Leopotam.Ecs;

using PewPew.Components.Common;
using PewPew.Lib.Factories;

namespace PewPew.Systems
{
    sealed class SpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<SpawnComponent> _spawnFilter = null;
        private PrefabFactory _factory = null;

        public SpawnSystem(PrefabFactory factory)
        {
            _factory = factory;
        }

        public void Init()
        {
            Dispatch();
        }

        public void Run()
        {
            Dispatch();
        }

        private void Dispatch()
        {
            if (_spawnFilter.IsEmpty())
                return;

            foreach (int i in _spawnFilter)
            {
                // create new empty entity
                ref EcsEntity entity = ref _spawnFilter.GetEntity(i);
                var prefabData = entity.Get<SpawnComponent>();

                // Instantiate new GameObject
                _factory.Spawn(ref entity, prefabData);

                // Remove SpawnComponent to prevent infinite clones
                entity.Del<SpawnComponent>();
            }
        }
    }
}

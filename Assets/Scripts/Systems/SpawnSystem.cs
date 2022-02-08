using Leopotam.Ecs;

using PewPew.Components.Common;
using PewPew.Lib.Factories;
using PewPew.UnityComponents;

namespace PewPew.Systems
{
    sealed class SpawnSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly SceneData _sceneData = null;
        private readonly EcsFilter<SpawnComponent> _spawnFilter = null;
        private PrefabFactory _factory = null;

        public SpawnSystem(PrefabFactory factory)
        {
            _factory = factory;
        }

        public void Run()
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

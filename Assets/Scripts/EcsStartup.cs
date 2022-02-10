using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components.Events;
using PewPew.Systems;
using PewPew.Systems.Common;
using PewPew.Systems.Input;
using PewPew.Systems.Player;
using PewPew.UnityComponents;

namespace PewPew
{
    sealed class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world = null;
        private EcsSystems _initSystems = null;
        private EcsSystems _updateSystems = null;
        private EcsSystems _fixedUpdateSystems = null;
        private GameControls _gameControls = null;
        [SerializeField]
        private SceneData _sceneData;
        [SerializeField]
        private StaticData _staticData;

        void Start()
        {
            _world = new EcsWorld();
            _initSystems = new EcsSystems(_world);
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
            _gameControls = new GameControls();

            _gameControls.Enable();

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_initSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_updateSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedUpdateSystems);
#endif

            _sceneData.prefabFactory.SetWorld(_world);

            _initSystems
                .Add(new CursorLockSystem())
                .Init();

            _updateSystems
                .OneFrame<JumpEvent>()
                .Add(new PlayerSpawnSystem())
                .Add(new SpawnSystem(_sceneData.prefabFactory))
                .Add(new InputDirectionSystem())
                .Add(new InputPlayerJumpSystem())
                .Add(new InputAxisSystem())
                .Add(new PlayerMoveSystem())
                .Add(new PlayerRotationSystem())
                .Add(new PlayerJumpSystem())
                .Inject(_gameControls)
                .Inject(_sceneData)
                .Inject(_staticData)
                .Init();

            _fixedUpdateSystems
                .Add(new CharacterSystem())
                .Add(new PhysicsSystem())
                .Add(new MoveSystem())
                .Add(new RotationSystem())
                .Inject(_gameControls)
                .Inject(_sceneData)
                .Inject(_staticData)
                .Init();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        private void Update()
        {
            _updateSystems?.Run();
        }

        void OnDestroy()
        {
            _gameControls?.Disable();

            _initSystems?.Destroy();
            _initSystems = null;

            _updateSystems?.Destroy();
            _updateSystems = null;

            _fixedUpdateSystems?.Destroy();
            _fixedUpdateSystems = null;

            _world.Destroy();
            _world = null;
        }
    }
}
using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components.Events;
using PewPew.Systems;
using PewPew.Systems.Camera;
using PewPew.Systems.Common;
using PewPew.Systems.Enemy;
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
        private EcsSystems _lateUpdateSystems = null;
        private GameControls _gameControls = null;
        [SerializeField]
        private SceneData _sceneData;
        [SerializeField]
        private StaticData _staticData;

        private EcsSystems SpawnSystems()
        {
            var systems = new EcsSystems(_world);
            systems
                .Add(new PlayerSpawnSystem())
                .Add(new EnemySpawnSystem());
            return systems;
        }

        private EcsSystems PlayersSystems()
        {
            var systems = new EcsSystems(_world);
            systems
                .Add(new PlayerMoveSystem())
                .Add(new PlayerRotationSystem())
                .Add(new PlayerJumpSystem());
            return systems;
        }

        private EcsSystems CameraSystems()
        {
            var systems = new EcsSystems(_world);
            systems
                .OneFrame<CameraChangeModeEvent>()
                .Add(new CameraInitSystem())
                .Add(new CameraInputSystem())
                .Add(new CameraChangeModeSystem())
                .Add(new CameraMoveSystem());
            return systems;
        }

        void Start()
        {
            _world = new EcsWorld();
            _initSystems = new EcsSystems(_world);
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
            _lateUpdateSystems = new EcsSystems(_world);
            _gameControls = new GameControls();

            _gameControls.Enable();

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_initSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_updateSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedUpdateSystems);
#endif

            _initSystems
                .Add(new CursorLockSystem())
                .Init();

            _updateSystems
                .Add(SpawnSystems())
                .Add(new SpawnSystem(_sceneData.prefabFactory))
                .Add(new InputAxisSystem())
                .Add(PlayersSystems())
                .OneFrame<EnemySpawnEvent>()
                .OneFrame<PlayerSpawnEvent>()
                .Inject(_gameControls)
                .Inject(_sceneData)
                .Inject(_staticData)
                .Init();

            _fixedUpdateSystems
                .Add(new MoveSystem())
                .Add(new RotationSystem())
                .Add(new VelocitySystem())
                .Inject(_gameControls)
                .Inject(_sceneData)
                .Inject(_staticData)
                .Init();

            _lateUpdateSystems
                .Add(CameraSystems())
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

        private void LateUpdate()
        {
            _lateUpdateSystems?.Run();
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

            _lateUpdateSystems?.Destroy();
            _lateUpdateSystems = null;

            _world.Destroy();
            _world = null;
        }
    }
}
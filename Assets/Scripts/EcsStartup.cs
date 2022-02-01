using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Systems;
using PewPew.UnityComponents;

namespace PewPew
{
    sealed class EcsStartup : MonoBehaviour
    {
        private EcsWorld world = null;
        private EcsSystems updateSystems = null;
        private EcsSystems lateUpdateSystems = null;
        public SceneData sceneData;

        void Start()
        {
            world = new EcsWorld();
            updateSystems = new EcsSystems(world);
            lateUpdateSystems = new EcsSystems(world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(updateSystems);
#endif

            updateSystems
                .OneFrame<JumpEvent>()
                .OneFrame<CameraChangeStateEvent>()
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new CameraChangeStateSystem())
                .Add(new JumpBlockSystem())
                .Add(new CursorLockSystem())
                .Add(new PlayerMovableInputSystem())
                .Add(new LookInputSystem())
                .Add(new PlayerMouseLookSystem())
                .Add(new GroundCheckSystem())
                .Add(new PlayerJumpSendEventSystem())
                .Add(new JumpSystem())
                .Add(new MovementSystem())
                .Inject(sceneData)
                .Init();

            lateUpdateSystems
                .Add(new CameraMoveSystem())
                .Add(new EnemyInitSystem())
                .Add(new EnemyMovementSystem())
                .Inject(sceneData)
                .Init();
        }

        private void LateUpdate()
        {
            lateUpdateSystems?.Run();
        }

        private void Update()
        {
            updateSystems?.Run();
        }

        void OnDestroy()
        {
            updateSystems?.Destroy();
            updateSystems = null;

            lateUpdateSystems?.Destroy();
            lateUpdateSystems = null;

            world.Destroy();
            world = null;
        }
    }
}
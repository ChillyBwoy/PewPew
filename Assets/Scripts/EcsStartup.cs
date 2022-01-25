using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

using PewPew.Components;
using PewPew.Systems;
using PewPew.UnityComponents;

namespace PewPew
{
    sealed class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world = null;
        private EcsSystems _systems = null;
        public SceneData sceneData;

        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif

            _systems
                .ConvertScene() // required by Voody.UniLeo
                .OneFrame<JumpEvent>()
                .Add(new DebugSystem())
                .Add(new JumpBlockSystem())
                .Add(new CursorLockSystem())
                .Add(new PlayerMovableInputSystem())
                .Add(new PlayerMouseInputSystem())
                .Add(new PlayerMouseLookSystem())
                .Add(new PlayerGroundCheckSystem())
                .Add(new PlayerJumpSendEventSystem())
                .Add(new PlayerJumpSystem())
                .Add(new MovementSystem())
                .Inject(sceneData)
                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}
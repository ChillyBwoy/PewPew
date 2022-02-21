using Leopotam.Ecs;

namespace PewPew.Services
{
    public class RuntimeData
    {
        private EcsEntity? playerEntity = null;
        private EcsEntity? cameraEntity = null;

        public EcsEntity? PlayerEntity
        {
            get => playerEntity;
            set => playerEntity = value;
        }

        public EcsEntity? CameraEntity
        {
            get => cameraEntity;
            set => cameraEntity = value;
        }
    }
}
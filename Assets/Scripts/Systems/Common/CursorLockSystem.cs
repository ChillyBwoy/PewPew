using UnityEngine;
using Leopotam.Ecs;

namespace PewPew.Systems
{
    sealed class CursorLockSystem : IEcsInitSystem
    {
        public void Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
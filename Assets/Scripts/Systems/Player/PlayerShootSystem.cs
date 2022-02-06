using UnityEngine;
using Leopotam.Ecs;
using PewPew.Components;

namespace PewPew.Systems
{
    sealed class PlayerShootSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, ShootEvent> filter = null;
        public void Run()
        {
            foreach (var i in filter)
            {
                ref var player = ref filter.Get1(i);

                GameObject bulletGO = GameObject.Instantiate(
                    player.bulletPrefab,
                    player.bulletSpawnPoint.position,
                    player.bulletSpawnPoint.rotation
                );

                Rigidbody rb = bulletGO.GetComponent<Rigidbody>();
                rb.AddForce(bulletGO.transform.forward * 50f, ForceMode.Impulse);
            }
        }
    }
}

using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Lib.MonoLink;

namespace PewPew.UnityComponents.MonoEntities
{
    public class ProjectileMonoEntity : MonoEntity
    {
        private void OnCollisionEnter(Collision other)
        {
            ContactPoint contactPoint = other.GetContact(0);

            if (entity.Has<ProjectileComponent>())
            {
                ref ProjectileComponent projectile = ref entity.Get<ProjectileComponent>();

                ParticleSystem particleSystem = GameObject.Instantiate(projectile.impactParticleSystem);
                particleSystem.transform.position = contactPoint.point;
                particleSystem.transform.forward = contactPoint.normal;
                particleSystem.Play();
            }

            Destroy(this.gameObject);
        }
    }
}

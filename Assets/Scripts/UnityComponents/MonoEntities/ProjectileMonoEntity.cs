using UnityEngine;
using PewPew.Lib.MonoLink;

namespace PewPew.UnityComponents.MonoEntities
{
    public class ProjectileMonoEntity : MonoEntity
    {
        private void OnCollisionEnter(Collision other)
        {
            Destroy(this.gameObject);
        }
    }
}

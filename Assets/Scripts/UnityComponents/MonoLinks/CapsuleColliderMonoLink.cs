using UnityEngine;

using PewPew.Components.Physics;
using PewPew.Lib.MonoLink;

namespace PewPew.UnityComponents.MonoLinks
{
    public class CapsuleColliderMonoLink : MonoLink<CapsuleColliderComponent>
    {
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (value.value == null)
            {
                value = new CapsuleColliderComponent
                {
                    value = GetComponent<CapsuleCollider>()
                };
            }
        }
#endif
    }
}

using UnityEngine;

using PewPew.Components.Physics;
using PewPew.Lib.MonoLink;

namespace PewPew.UnityComponents.MonoLinks
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyMonoLink : MonoLink<RigidbodyComponent>
    {

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (value.value == null)
            {
                value = new RigidbodyComponent
                {
                    value = GetComponent<Rigidbody>()
                };
            }
        }
#endif
    }
}

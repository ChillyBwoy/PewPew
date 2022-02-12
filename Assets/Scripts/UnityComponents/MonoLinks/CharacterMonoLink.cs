using UnityEngine;
using PewPew.Components;
using PewPew.Lib.MonoLink;

namespace PewPew.UnityComponents.MonoLinks
{
    public class CharacterMonoLink : MonoLink<CharacterComponent>
    {
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (properties.collider == null)
            {
                properties.collider = GetComponent<Collider>();
            }

            if (properties.rigidbody == null)
            {
                properties.rigidbody = GetComponent<Rigidbody>();
            }
        }
#endif
    }
}

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
            if (value.capsuleCollider == null)
            {
                value.capsuleCollider = GetComponent<CapsuleCollider>();
            }

            if (value.rigidbody == null)
            {
                value.rigidbody = GetComponent<Rigidbody>();
            }
        }
#endif
    }
}

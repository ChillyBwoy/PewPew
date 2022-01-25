using UnityEngine;
using Voody.UniLeo;
using PewPew.Components;

namespace PewPew.UnityComponents
{
    public class EcsTriggerChecker : MonoBehaviour
    {
        [SerializeField] private string targetTag = "Player";
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(targetTag)) return;

            WorldHandler.GetWorld().SendMessage(new DebugMessageRequestComponent()
            {
                message = "Player is here"
            });
        }
    }
}

using UnityEngine;

namespace PewPew.UnityComponents
{
    public class EcsTriggerChecker : MonoBehaviour
    {
        [SerializeField] private string targetTag = "Player";
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(targetTag)) return;

            Debug.Log("Player enters the collider");
        }
    }
}

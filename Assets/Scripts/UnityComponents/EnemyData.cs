using UnityEngine;

namespace PewPew.UnityComponents
{
    public class EnemyData : MonoBehaviour
    {
        [Header("Movable")]
        public CharacterController characterController;
        public float speed;
        public float gravity;
    }
}

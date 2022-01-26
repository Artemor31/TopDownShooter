using UnityEngine;

namespace Ecs.Components
{
    struct PlayerComponent
    {
        public Transform PlayerTransform;
        public Rigidbody PlayerRigidbody;
        public float PlayerSpeed;
        public float PlayerVelocity;
    }
}
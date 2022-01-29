using UnityEngine;

namespace Ecs.Configuration
{
    [CreateAssetMenu(menuName = "Create Configuraion", fileName = "Configuraion", order = 0)]
    public class Configuraion : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public float PlayerSpeed;
        public float PlayerVelocity;
    }
}

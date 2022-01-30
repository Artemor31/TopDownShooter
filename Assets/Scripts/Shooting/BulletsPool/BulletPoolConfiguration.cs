using UnityEngine;


namespace Pooling
{
     [CreateAssetMenu(fileName = "Pooling", menuName = "BulletPoolConfig", order = 0)]
    public class BulletPoolConfiguration : ScriptableObject
    {
        public GameObject BulletPrefab;
        public int PoolSize;
    }
}

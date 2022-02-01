using UnityEngine;


[CreateAssetMenu(fileName = "Pooling", menuName = "BulletPoolConfig", order = 0)]
public class BulletPoolConfiguration : ScriptableObject
{
    public int PoolSize;
    public GameObject BulletPrefab;
}


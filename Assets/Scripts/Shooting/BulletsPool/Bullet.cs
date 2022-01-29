using System;
using UnityEngine;

namespace BulletsPool
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Shooting.BulletsPool.BulletsPool _pool;

        public void SetParentPool(Shooting.BulletsPool.BulletsPool pool) => _pool = pool;

        public void PoolBack() => _pool.StackBullet(this);

        private void Update()
        {
            transform.position += Vector3.right * (Time.deltaTime * _speed);
        }
    }
}
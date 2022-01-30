using System;
using Pooling;
using UnityEngine;

   public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private BulletsPool _pool;

        public void SetParentPool(BulletsPool pool) => _pool = pool;

        public void PoolBack() => _pool.StackBullet(this);

        private void Update()
        {
            transform.position += Vector3.right * (Time.deltaTime * _speed);
        }
    }

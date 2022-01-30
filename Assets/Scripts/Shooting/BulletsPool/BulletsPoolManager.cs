using System;
using Pooling;
using Unity.VisualScripting;
using UnityEngine;


    public class BulletsPoolManager : MonoBehaviour
    {
        [SerializeField] private BulletPoolConfiguration _configuration;
        private BulletsPool _pool;

        private void OnEnable()
        {
            _pool = new BulletsPool(_configuration);
            _pool.Initialize();
        }

        public Bullet GetBullet()
        {
            var bullet = _pool.PopBullet();
            return new Bullet();
        }
    }

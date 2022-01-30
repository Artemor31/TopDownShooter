using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Pooling
{
    public class BulletsPool
    {
        private readonly BulletPoolConfiguration _configuration;
        private Stack<Bullet> _objects;

        public BulletsPool(BulletPoolConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        public void Initialize()
        {
            _objects = new Stack<Bullet>(_configuration.PoolSize);

            for (int i = 0; i < _configuration.PoolSize; i++)
            {
                StackNewBullet();
            }
        }

        private void StackNewBullet()
        {
            var gameObj = Object.Instantiate(_configuration.BulletPrefab);
            var bullet = gameObj.GetComponent<Bullet>();
            _objects.Push(bullet);

            bullet.SetParentPool(this);
            gameObj.SetActive(false);
        }

        public Bullet PopBullet()
        {
            if (_objects.Count == 0)
            {
                StackNewBullet();
            }

            return _objects.Pop();
        }

        public void StackBullet(Bullet bullet) => _objects.Push(bullet);
    }
}
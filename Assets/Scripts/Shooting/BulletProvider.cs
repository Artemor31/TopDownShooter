using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ecs.Configuration;
using Leopotam.Ecs;
using Unity.VisualScripting;
using UnityEngine;


public class BulletProvider
{
    private readonly BulletsPool _pool;

    public BulletProvider(BulletPoolConfiguration configuration, BulletsConfiguration bulletsConfiguration, EcsWorld world)
    {
        _pool = new BulletsPool(configuration, bulletsConfiguration, world);
        _pool.Initialize();
    }

    public void Shoot(Vector3 start, Vector3 target)
    {
        var bullet = _pool.PopBullet();
        
        bullet.transform.position = start;
        bullet.transform.LookAt(target);
        bullet.gameObject.SetActive(true);
    }

    public void Collect(BulletView bulletView)
    {
        bulletView.gameObject.SetActive(false);
        _pool.StackBullet(bulletView);
    }


    private class BulletsPool
    {
        private readonly BulletPoolConfiguration _configuration;
        private readonly BulletsConfiguration _bulletsConfiguration;
        
        private readonly EcsWorld _world;
        private Stack<BulletView> _bullets;

        public BulletsPool(BulletPoolConfiguration configuration, BulletsConfiguration bulletsConfiguration, EcsWorld world)
        {
            _configuration = configuration;
            _bulletsConfiguration = bulletsConfiguration;
            _world = world;
        }

        public void Initialize()
        {
            _bullets = new Stack<BulletView>(_configuration.PoolSize);

            for (int i = 0; i < _configuration.PoolSize; i++)
            {
                var bullet = StackNewBullet();
                CreateNewBulletEntity(bullet);
            }
        }

        private void CreateNewBulletEntity(BulletView bullet)
        {
            ref var bulletComponent = ref _world.NewEntity().Get<BulletComponent>();
            
            bulletComponent.Speed = _bulletsConfiguration.Speed;
            bulletComponent.Bullet = bullet.gameObject;
            bullet.Init(_world);
        }

        private BulletView StackNewBullet()
        {
            var gameObj = Object.Instantiate(_configuration.BulletPrefab);
            var bullet = gameObj.GetComponent<BulletView>();
            _bullets.Push(bullet);

            gameObj.SetActive(false);
            return bullet;
        }

        public BulletView PopBullet()
        {
            if (_bullets.Count == 0)
            {
                StackNewBullet();
            }

            return _bullets.Pop();
        }

        public void StackBullet(BulletView bulletView) => _bullets.Push(bulletView);
    }

}

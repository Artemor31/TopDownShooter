using System.Collections.Generic;
using Leopotam.Ecs;
using Pooling;
using Unity.VisualScripting;
using UnityEngine;

public class BulletsPool : IEcsSystem
{
    private readonly BulletPoolConfiguration _configuration;
    private Stack<BulletView> _bullets;

    public BulletsPool(BulletPoolConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Initialize()
    {
        _bullets = new Stack<BulletView>(_configuration.PoolSize);

        for (int i = 0; i < _configuration.PoolSize; i++)
        {
            StackNewBullet();
        }
    }

    private void StackNewBullet()
    {
        var gameObj = Object.Instantiate(_configuration.BulletPrefab);
        var bullet = gameObj.GetComponent<BulletView>();
        _bullets.Push(bullet);

        bullet.SetParentPool(this);
        gameObj.SetActive(false);
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

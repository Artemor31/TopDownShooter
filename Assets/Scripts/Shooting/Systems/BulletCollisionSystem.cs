using Leopotam.Ecs;
using UnityEngine;

sealed class BulletCollisionSystem : IEcsRunSystem
{
    readonly EcsWorld _world = null;
    readonly BulletProvider _bulletProvider = null;
    private EcsFilter<BulletCollisionEvent> _filter = default;

    void IEcsRunSystem.Run()
    {
        foreach (var idx in _filter)
        {
            ref var collisionEvent = ref _filter.Get1(idx);
            var bulletView = collisionEvent.Bullet.GetComponent<BulletView>();
            _bulletProvider.Collect(bulletView);
            
            // Here we can create explosion, blood particles, etc. Do i need another system or event?
        }
    }
}

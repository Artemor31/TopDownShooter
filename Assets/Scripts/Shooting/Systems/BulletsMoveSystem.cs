using Leopotam.Ecs;
using UnityEngine;

public class BulletsMoveSystem : IEcsRunSystem
{
    private EcsWorld _world = default;
    private EcsFilter<BulletComponent> _filter = default;

    public void Run()
    {
        foreach (var idx in _filter)
        {
            ref var bulletComponent = ref _filter.Get1(idx);
            if (bulletComponent.Bullet.activeInHierarchy == false) continue;
            
            bulletComponent.Bullet.transform.position += Time.deltaTime * Vector3.one * bulletComponent.Speed;
        }
    }
}

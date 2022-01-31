using System;
using Leopotam.Ecs;
using Pooling;

public class BulletPoolInitSystem : IEcsInitSystem
{
    private BulletPoolConfiguration _configuration = default;
    private EcsWorld _world;
    
    public void Init()
    {
        var entity = _world.NewEntity();
        ref var pool = ref entity.Get<BulletPoolComponent>();
        
        pool.BulletsPool = new BulletsPool(_configuration);
        pool.BulletsPool.Initialize();
    }
}


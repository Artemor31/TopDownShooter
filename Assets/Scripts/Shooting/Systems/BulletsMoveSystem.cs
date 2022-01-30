using Leopotam.Ecs;
using UnityEngine;

namespace Shooting
{
    public class BulletsMoveSystem : IEcsRunSystem
    {
        private EcsWorld _world = default;
        private EcsFilter<BulletComponent> _filter = default;
        
        public void Run()
        {
            foreach (var idx in _filter)
            {
                var bulletComponent = _filter.Get1(idx);
            }
        }
    }
}
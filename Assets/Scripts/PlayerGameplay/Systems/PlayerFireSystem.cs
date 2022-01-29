using BulletsPool;
using Leopotam.Ecs;
using PlayerGameplay.Components;
using UnityEngine;

namespace PlayerGameplay.Systems
{
    sealed class PlayerFireSystem : IEcsRunSystem
    {
        private Shooting.BulletsPool.BulletsPool _bulletsPool;
        private readonly EcsWorld _world = null;
        private EcsFilter<FireButtonPressedEvent> _filter = default;

        void IEcsRunSystem.Run()
        {
            foreach (var idx in _filter)
            {
                var bullet = _bulletsPool.PopBullet();
                bullet.gameObject.SetActive(true);
                Debug.Log("<color=red>FIRE</color>"); 
            }
        }
    }
}
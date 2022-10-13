using Leopotam.Ecs;
using PlayerGameplay.Components;
using UnityEngine;

namespace PlayerGameplay.Systems
{
    sealed class PlayerFireSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private BulletProvider _bulletProvider;
        private EcsFilter<FireButtonPressedEvent> _filter = default;
        private EcsFilter<PlayerComponent> _filterPlayer = default;

        public void Run()
        {
            foreach (var _ in _filter)
            {
                foreach (var p in _filterPlayer)
                {
                    var playerComponent = _filterPlayer.Get1(p);
                    _bulletProvider.Shoot(playerComponent.PlayerTransform.position, Vector3.one);
                }
            }
        }
    }
}
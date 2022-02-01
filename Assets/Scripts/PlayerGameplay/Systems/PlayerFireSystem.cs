using Leopotam.Ecs;
using PlayerGameplay.Components;

namespace PlayerGameplay.Systems
{
    sealed class PlayerFireSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private EcsFilter<FireButtonPressedEvent> _filter = default;
        private EcsFilter<PlayerComponent> _playerFilter = default;

        void IEcsRunSystem.Run()
        {
            foreach (var idx in _filter)
            {
            }
        }
    }
}
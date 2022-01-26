using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems
{
    sealed class MovePlayerSystem : IEcsRunSystem
    {
        private EcsWorld _world = default;
        private EcsFilter<UserInputComponent> _inputFilter = default;
        private EcsFilter<PlayerComponent> _playerFilter = default;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _inputFilter)
            {
                ref var input = ref _inputFilter.Get1(i);

                foreach (var j in _playerFilter)
                {
                    ref var player = ref _playerFilter.Get1(j);
                    player.PlayerTransform.position += input.MoveInput.ToVector3() * player.PlayerSpeed;
                    Debug.Log(input.MoveInput); 
                }
            }
        }
    }
}
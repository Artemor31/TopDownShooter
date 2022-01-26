using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;


namespace Ecs.Systems
{
    sealed class GetUserInputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;

        void IEcsRunSystem.Run()
        {
            var moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (moveInput.sqrMagnitude > 0.1f)
            {
                _world.NewEntity()
                      .Get<UserInputComponent>()
                      .MoveInput = moveInput;
            }
        }
    }
}
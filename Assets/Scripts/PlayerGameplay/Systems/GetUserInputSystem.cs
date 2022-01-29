using Leopotam.Ecs;
using PlayerGameplay.Components;
using UnityEngine;

namespace PlayerGameplay.Systems
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

            if (Input.GetMouseButton(0))
            {
                _world.NewEntity().Get<FireButtonPressedEvent>();
            }
        }
    }
}
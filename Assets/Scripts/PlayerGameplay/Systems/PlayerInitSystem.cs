using Ecs.Configuration;
using Leopotam.Ecs;
using PlayerGameplay.Components;
using UnityEngine;

namespace Ecs.Systems
{
    class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld = default;
        private Configuraion _configuraion;

        public void Init()
        {
            var player = _ecsWorld.NewEntity();
            ref var playerComponent = ref player.Get<PlayerComponent>();

            var playerGameObject = GameObject.FindWithTag("Player");

            playerComponent.PlayerSpeed = _configuraion.PlayerSpeed;
            playerComponent.PlayerTransform = playerGameObject.transform;
            playerComponent.WeaponTransform = playerGameObject.transform;
        }
    }
}
using Ecs.Configuration;
using Ecs.Systems;
using Leopotam.Ecs;
using PlayerGameplay.Components;
using PlayerGameplay.Systems;
using UnityEngine;

namespace Ecs.Services
{
    sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] private Configuraion _configuraion;
        [SerializeField] private Shooting.BulletsPool.BulletsPool _pool;
        
        EcsWorld _world;
        EcsSystems _initSystems;
        EcsSystems _updateSystems;

        void Start()
        {
            _world = new EcsWorld();
            _initSystems = new EcsSystems(_world);
            _updateSystems = new EcsSystems(_world);

            _initSystems.Add(new PlayerInitSystem())
                .Inject(_configuraion);

            _updateSystems.Add(new PlayerInitSystem())
                .OneFrame<UserInputComponent>()
                .OneFrame<FireButtonPressedEvent>()
                .Add(new GetUserInputSystem())
                .Add(new MovePlayerSystem())
                .Add(new PlayerFireSystem())
                .Inject(_configuraion)
                .Inject(_pool);
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
#endif
            
            _initSystems.Init();
            _updateSystems.Init();
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_initSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_updateSystems);
#endif
        }

        void Update()
        {
            _updateSystems?.Run();
        }

        void OnDestroy()
        {
            if (_updateSystems != null)
            {
                _initSystems.Destroy();
                _updateSystems.Destroy();
                _updateSystems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}
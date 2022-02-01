using System;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Collider))]
public class BulletView : MonoBehaviour
{
    private EcsWorld _world;

    public void Init(EcsWorld world) => _world = world;

    private void OnCollisionEnter(Collision other)
    {
        ref var bulletEvent = ref _world.NewEntity().Get<BulletCollisionEvent>();
        bulletEvent.Bullet = transform;
        bulletEvent.Target = other.transform;
        bulletEvent.CollisionPosition = transform.position;
    }
}

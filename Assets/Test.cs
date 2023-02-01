using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;
using CollisionSystem;

public class Test : IFixedUpdateSystem
{
    private Filter<EnterCollisionEvent> _enterCollisionEvents = Filter.Create<EnterCollisionEvent>();
    private Filter<ExitCollisionEvent> _exitCollisionEvents = Filter.Create<ExitCollisionEvent>();
    private Filter<StayCollisionEvent> _stayCollisionEvents = Filter.Create<StayCollisionEvent>();

    public void FixedUpdate(float deltaTime)
    {
        foreach (var enter in _enterCollisionEvents)
        {
            Debug.Log($"-ENTER- Name: {enter.CollisionInfo.HitInfo.collider}, Side: {enter.CollisionInfo.CollisionSide}");

            Debug.DrawRay(enter.Sender.transform.position, enter.CollisionInfo.HitInfo.normal, Color.red);

            Debug.Log($"CollisionCount: {(enter.Sender as BoxCollisionDetector).Collisions.Count}");
        }

        foreach (var exit in _exitCollisionEvents)
        {
            Debug.Log($"_EXIT- Name: {exit.CollisionInfo.HitInfo.collider}, Side: {exit.CollisionInfo.CollisionSide}");

            Debug.Log($"CollisionCount: {(exit.Sender as BoxCollisionDetector).Collisions.Count}");
        }

        foreach (var stay in _stayCollisionEvents)
        {
            Debug.Log($"-STAY- Name: {stay.CollisionInfo.HitInfo.collider}, Side: {stay.CollisionInfo.CollisionSide}");

            Debug.DrawRay(stay.Sender.transform.position, stay.CollisionInfo.HitInfo.normal, Color.red);
        }
    }
}
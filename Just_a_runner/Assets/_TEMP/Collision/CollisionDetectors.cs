using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;
using System;

namespace CollisionSystem
{
    public class CollisionDetectors : ISystem
    {
        private Filter<EnterCollisionEvent> _enterCollisionEvents = new();
        private Filter<StayCollisionEvent> _stayCollisionEvents = new();

        //private Filter<ComponentAdded> _addedComponents = new();//Filter.Create<ComponentAdded>();

        public void FixedUpdate(float deltaTime)
        {
            //foreach (var component in _addedComponents)
                //if (component.Component is ICollisionDetector)
                //    Initialize(component.Component);

            //foreach (var enter in _enterCollisionEvents)
              //  Debug.Log($"-Enter- ObjectName: {enter.CollisionInfo.gameObject.name}");

            //foreach (var stay in _stayCollisionEvents)
              //  Debug.Log($"-Stay- ObjectName: {stay.CollisionInfo.gameObject.name}");
        }

        private void Initialize(EcsComponent detector)
        {
            if (detector is EnterCollisionDetector enterDetector)
                enterDetector.LastEventSent = new(detector, null);
            else if (detector is StayCollisionDetector stayDetector)
                stayDetector.LastEventSent = new(detector, null);

            if (!detector.TryGetComponent(out Collider c))
                detector.gameObject.AddComponent<BoxCollider>();

            if (detector.TryGetComponent(out Rigidbody r))
                return;

            var rigidbody = detector.gameObject.AddComponent<Rigidbody>();

            rigidbody.useGravity = false;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
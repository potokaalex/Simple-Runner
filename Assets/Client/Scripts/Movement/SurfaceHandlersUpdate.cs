using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Ecs;

namespace MovementSystem
{
    public class SurfaceHandlersUpdate : IFixedUpdateSystem
    {
        /*
        private Filter<SurfaceHandler> _handlers = Filter.Create<SurfaceHandler>();
        private Filter<EnterCollisionEvent> _enterEvents = Filter.Create<EnterCollisionEvent>();
        private Filter<ExitCollisionEvent> _exitEvents = Filter.Create<ExitCollisionEvent>();

        public void FixedUpdate(float deltaTime)
        {
            foreach (var handler in _handlers)
            {
                foreach (var enter in _enterEvents)
                {
                    if (enter.Sender != handler.EnterCollisionDetector)
                    {
                        //Debug.Log("FirstCondition");

                        continue;
                    }


                    //if (handler.EnterCollisionDetector.Collision.contacts.Length < 1)
                    //{
                        //Debug.Log("Second");

                     //   continue;

                    //}

                    //handler.SurfaceNormal = enter.Contact.contacts[0].normal;

                    //sTryAddContactPoint(handler, );
                    //RecalculateAverageNormal(handler);
                }


                foreach (var exit in _exitEvents)
                {
                    //if (exit.Sender != handler.ExitCollisionDetector)
                     //   continue;

                    

                    //TryRemoveContactPoint(handler, exit.Contact.collider);
                    //RecalculateAverageNormal(handler);
                }

            }
        }

        public void TryAddContactPoint(SurfaceHandler handlers, ContactPoint point)
        {
            foreach (var contactPoint in handlers.SurfaceContacts)
                if (contactPoint.otherCollider == point.otherCollider)
                    return;

            handlers.SurfaceContacts.Add(point);


            //handlers.SurfaceNormal = Vector3.Lerp(handlers.SurfaceNormal, point.normal, 0.5f);
        }

        public void TryRemoveContactPoint(SurfaceHandler handlers, Collider contactCollider)
        {
            var removablePonit = new ContactPoint();

            foreach (var contactPoint in handlers.SurfaceContacts)
                if (contactPoint.otherCollider == contactCollider)
                    removablePonit = contactPoint;

            handlers.SurfaceContacts.Remove(removablePonit);
        }

        public void RecalculateAverageNormal(SurfaceHandler handlers)
        {
            //return;

            Debug.Log("Recalculte");

            var count = handlers.SurfaceContacts.Count;

            handlers.SurfaceNormal = Vector3.zero;

            if (count < 1)
                return;

            foreach (var n in handlers.SurfaceContacts)
                handlers.SurfaceNormal += n.normal;

            handlers.SurfaceNormal /= count;
        }
        */
        public void FixedUpdate(float deltaTime)
        {

        }
    }
}
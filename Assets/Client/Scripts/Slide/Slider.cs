using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Ecs;

namespace Slider
{
    public class Slider : EcsComponent
    {
        private List<ContactPoint> _contacPoints = new();
        private Vector3 _normal;

        public Vector3 GetAverageNormal()
            => _normal;

        private void FixedUpdate()
        {
            Debug.DrawRay(transform.position, _normal, Color.cyan);
        }

        public void TryAddContactPoint(ContactPoint point)
        {
            foreach (var contactPoint in _contacPoints)
                if (contactPoint.otherCollider == point.otherCollider)
                    return;

            _contacPoints.Add(point);
        }

        public void TryRemoveContactPoint(Collider contactCollider)
        {
            //if (contactCollider == null)
              //  return;

            var removablePonit = new ContactPoint();

            foreach (var contactPoint in _contacPoints)
                if (contactPoint.otherCollider == contactCollider)
                    removablePonit = contactPoint;// _contacPoints.Remove(contactPoint);

            _contacPoints.Remove(removablePonit);

            //Debug.Log($"Removable name: {removablePonit.otherCollider.name}");
            //Debug.Log($"ContacPoints count: {_contacPoints.Count}");
        }

        public void RecalculateAverageNormal()
        {
            var count = _contacPoints.Count;

            _normal = Vector3.zero;

            if (count < 1)
                return;

            foreach (var n in _contacPoints)
                _normal += n.normal;

            _normal /= count;
        }
    }
}

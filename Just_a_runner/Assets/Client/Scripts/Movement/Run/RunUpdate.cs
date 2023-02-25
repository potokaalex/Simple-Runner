using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using UnityEngine;

namespace MovementSystem
{
    public class RunUpdate : IFixedUpdateSystem
    {
        private Filter<Run> _runComponents = new();

        public void FixedUpdate(float deltaTime)
        {
            foreach (var component in _runComponents)
            {
                //UpdateMove(component, deltaTime);

                //Debug.DrawRay(component.transform.position, component.transform.rotation * Vector3.forward, Color.green);


                //Debug.DrawRay(component.transform.position, component.SurfaceHandler.SurfaceNormal, Color.red);
            }
        }

        private void UpdateMove(Run component, float deltaTime)
        {
            component.AccelerationReader ??= new(component.Acceleration);

            component.transform.position += component.Velocity * deltaTime * (component.transform.rotation * Vector3.forward);

            //component.transform.rotation = Quaternion.AngleAxis(Vector3.Angle(Vector3.forward, GetProjection(component)), Vector3.left);

            component.Velocity += component.AccelerationReader.GetIncrement();
            component.AccelerationReader.Move(deltaTime);
        }

        private Vector3 GetProjection(Vector3 normal) => Vector3.forward - Vector3.Dot(Vector3.forward, normal) * normal;
    }
}
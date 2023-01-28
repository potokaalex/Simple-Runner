using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Ecs;
using InputSystem;

namespace MovementSystem
{
    public class MoveUpdate : IFixedUpdateSystem
    {
        private ComponentFilter<MoveForward> _moveForwardComponents = new();
        private ComponentFilter<MoveRight> _moveRightComponents = new();
        private ComponentFilter<MoveLeft> _moveLeftComponents = new();

        private EventFilter<KeyDown> _keys;

        public void FixedUpdate(float deltaTime)
        {
            foreach (var component in _moveForwardComponents)
                MoveForward(component, deltaTime);
            foreach (var component in _moveRightComponents)
                MoveRight(component, deltaTime);
            foreach (var component in _moveLeftComponents)
                MoveLeft(component, deltaTime);
        }

        private void MoveForward(MoveForward component, float deltaTime)
        {
            if (component.AccelerationReader == null)
                component.AccelerationReader = new(component.Acceleration);

            component.transform.position += Vector3.forward * component.Velocity * deltaTime;

            component.Velocity += component.AccelerationReader.GetValue() * deltaTime;
            component.AccelerationReader.Move(deltaTime);
        }

        private void MoveRight(MoveRight component, float deltaTime)
        {
            if (component.AccelerationReader == null)
                component.AccelerationReader = new(component.Acceleration);

            component.transform.position += Vector3.right * component.Velocity * deltaTime;

            component.Velocity += component.AccelerationReader.GetValue() * deltaTime;
            component.AccelerationReader.Move(deltaTime);

        }
        private void MoveLeft(MoveLeft component, float deltaTime)
        {
            if (component.AccelerationReader == null)
                component.AccelerationReader = new(component.Acceleration);

            component.transform.position += Vector3.left * component.Velocity * deltaTime;

            component.Velocity += component.AccelerationReader.GetValue() * deltaTime;
            component.AccelerationReader.Move(deltaTime);

        }

        private void Move(MoveForward component, float deltaTime)
        {
            if (component.AccelerationReader == null)
                component.AccelerationReader = new(component.Acceleration);

            component.transform.position += Vector3.forward * component.Velocity * deltaTime;

            component.Velocity += component.AccelerationReader.GetValue() * deltaTime;
            component.AccelerationReader.Move(deltaTime);
        }

        /*
        private void Move(Move component, float deltaTime)
        {
            if (component.AccelerationReader == null)
                component.AccelerationReader = new(component.AnimationAcceleration);

            var velocity = component.Velocity * deltaTime;

            component.transform.position += component.NormalizedDirection.normalized * velocity;

            component.Velocity += component.AccelerationReader.GetValue() * deltaTime;
            component.AccelerationReader.Move(deltaTime);
        }
        */
    }
}

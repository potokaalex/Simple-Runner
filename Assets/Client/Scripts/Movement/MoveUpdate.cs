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
        private Filter<MoveForward> _moveForwardComponents = Filter.Create<MoveForward>();
        private Filter<MoveRight> _moveRightComponents = Filter.Create<MoveRight>();
        private Filter<MoveLeft> _moveLeftComponents = Filter.Create<MoveLeft>();
        private Filter<KeyDown> _keys = Filter.Create<KeyDown>();

        public void FixedUpdate(float deltaTime)
        {
            foreach (var component in _moveForwardComponents)
                MoveForward(component, deltaTime);

            foreach (var component in _moveRightComponents)
                if (IsKeysContains(KeyCode.D))
                    MoveRight(component, deltaTime);

            foreach (var component in _moveLeftComponents)
                if (IsKeysContains(KeyCode.A))
                    MoveLeft(component, deltaTime);

            UpdateMovement();
        }

        private bool IsKeysContains(KeyCode keyCode)
        {
            foreach (var key in _keys)
                if (key.KeyCode == keyCode)
                    return true;

            return false;
        }

        private void MoveForward(MoveForward component, float deltaTime)
        {
            if (component.AccelerationReader == null)
                component.AccelerationReader = new(component.Acceleration);

            var direction = Vector3.forward;
            var velocity = component.AccelerationReader.GetValue() * deltaTime;

            component.transform.position += direction * velocity;

            component.Velocity += velocity;
            component.AccelerationReader.Move(deltaTime);
        }

        private void MoveRight(MoveRight component, float deltaTime)
        {
            if (component.AccelerationReader == null)
                component.AccelerationReader = new(component.Acceleration);

            //if (component.AccelerationReader.GetIncrement() != 0)
            //    return;

            var direction = Vector3.right;
            var velocity = component.AccelerationReader.GetIncrement();

            component.transform.position += direction * velocity;
            component.AccelerationReader.Move(deltaTime);
        }

        private void MoveLeft(MoveLeft component, float deltaTime)
        {
            if (component.AccelerationReader == null)
                component.AccelerationReader = new(component.Acceleration);

            if (component.AccelerationReader.GetIncrement() != 0)
                return;

            var direction = Vector3.left;
            var velocity = component.AccelerationReader.GetIncrement();

            component.transform.position += direction * velocity;
            component.AccelerationReader.Move(deltaTime);
        }

        private void UpdateMovement()
        {
            //MoveForward();
            //MoveRight();
            // MoveLeft();
        }
    }

    public class MoveRightUpdate : IFixedUpdateSystem
    {
        private Filter<MoveRight> _moveRightComponents = Filter.Create<MoveRight>();
        private Filter<KeyDown> _keys = Filter.Create<KeyDown>();

        public void FixedUpdate(float deltaTime)
        {
            foreach (var key in _keys)
            {
                _moveRightComponents = Filter.Create<MoveRight>();
            }


            // throw new NotImplementedException();
        }

        private void StartMove() { }
        private void UpdateMove() { }

    }

    public class MoveDirection2
    {

    }
}

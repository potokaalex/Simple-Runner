using UnityEngine;
using InputSystem;
using Ecs;

namespace MovementSystem
{
    public class MoveRightUpdate : MoveSideUpdate, IFixedUpdateSystem
    {
        private Filter<MoveRight> _moveRightComponents = Filter.Create<MoveRight>();
        private Filter<KeyDown> _keys = Filter.Create<KeyDown>();

        public void FixedUpdate(float deltaTime)
        {
            foreach (var component in _moveRightComponents)
            {
                if (IsInputCondition())
                    StartMove(component);

                UpdateMove(component, Vector3.right, deltaTime);
            }
        }

        private bool IsInputCondition()
        {
            foreach (var key in _keys)
                if (key.KeyCode == KeyCode.D)
                    return true;

            return false;
        }
    }
}

using UnityEngine;
using InputSystem;
using Ecs;

namespace MovementSystem
{
    public class MoveLeftUpdate : MoveSideUpdate, IFixedUpdateSystem
    {
        private Filter<MoveLeft> _moveLeftComponents = Filter.Create<MoveLeft>();
        private Filter<KeyDown> _keys = Filter.Create<KeyDown>();

        public void FixedUpdate(float deltaTime)
        {
            foreach (var component in _moveLeftComponents)
            {
                if (IsInputCondition())
                    StartMove(component);

                UpdateMove(component,Vector3.left, deltaTime);
            }
        }

        private bool IsInputCondition()
        {
            foreach (var key in _keys)
                if (key.KeyCode == KeyCode.A)
                    return true;

            return false;
        }
    }
}

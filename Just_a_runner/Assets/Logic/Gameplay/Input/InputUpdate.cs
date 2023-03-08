using UnityEngine;
using Ecs;

namespace InputSystem
{
    public class InputUpdate : ITickable
    {
        public void Tick(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.A))
                World.Events.Add(new MoveLeftKey());

            if (Input.GetKeyDown(KeyCode.D))
                World.Events.Add(new MoveRightKey());
        }
    }
}
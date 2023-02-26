using UnityEngine;
using Ecs;

namespace InputSystem
{
    public class InputUpdate : ITickable
    {
        private KeyDown_W _keyDown_W = new();
        private KeyDown_A _keyDown_A = new();
        private KeyDown_S _keyDown_S = new();
        private KeyDown_D _keyDown_D = new();
        private KeyDown_Space _keyDown_Space = new();

        public void Tick(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
                World.Events.Add(_keyDown_W);

            if (Input.GetKeyDown(KeyCode.A))
                World.Events.Add(_keyDown_A);

            if (Input.GetKeyDown(KeyCode.S))
                World.Events.Add(_keyDown_S);

            if (Input.GetKeyDown(KeyCode.D))
                World.Events.Add(_keyDown_D);

            if (Input.GetKeyDown(KeyCode.Space))
                World.Events.Add(_keyDown_Space);
        }
    }
}
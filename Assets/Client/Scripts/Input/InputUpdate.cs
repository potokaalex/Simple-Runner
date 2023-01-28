using System.Collections.Generic;
using UnityEngine;
using System;
using Ecs;

namespace InputSystem
{
    public class InputUpdate : IUpdateSystem
    {
        public void Update(float deltaTime)
        {
            TrySendKeyDownEvent(KeyCode.W);
            TrySendKeyDownEvent(KeyCode.A);
            TrySendKeyDownEvent(KeyCode.S);
            TrySendKeyDownEvent(KeyCode.D);
            TrySendKeyDownEvent(KeyCode.Space);
        }

        private void TrySendKeyDownEvent(KeyCode keyCode)
        {
            if (Input.GetKeyDown(keyCode))
                EcsWorld.AddEvent(new KeyDown(keyCode));
        }
    }
}

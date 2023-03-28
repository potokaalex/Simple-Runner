using Infrastructure;
using UnityEngine;
using Zenject;
using System;
using Ecs;

namespace InputService
{
    public class TouchesInput : IInitializable, IDisposable
    {
        private IGameLoop _gameLoop;

        [Inject]
        public TouchesInput(IGameLoop gameLoop)
            => _gameLoop = gameLoop;

        public void Initialize()
            => _gameLoop.OnTick += Tick;

        public void Dispose()
            => _gameLoop.OnTick -= Tick;

        private void Tick(float deltaTime)
        {
            if (Input.touchCount == 0)
                return;

            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < Screen.width / 2)
                    World.Events.Add(new MoveLeftKey());
                else
                    World.Events.Add(new MoveRightKey());
            }
        }
    }
}

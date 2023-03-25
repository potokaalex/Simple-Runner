using Infrastructure;
using UnityEngine;
using Zenject;
using System;
using Ecs;

namespace InputService
{
    public class KeyboardInput : IInitializable, IDisposable
    {
        private IGameLoop _gameLoop;

        [Inject]
        public KeyboardInput(IGameLoop gameLoop)
            => _gameLoop = gameLoop;

        public void Initialize()
            => _gameLoop.OnTick += Tick;

        public void Dispose()
            => _gameLoop.OnTick -= Tick;

        private void Tick(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                World.Events.Add(new MoveLeftKey());

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                World.Events.Add(new MoveRightKey());

            if (Input.GetKeyDown(KeyCode.Space))
                World.Events.Add(new RestartKey());
        }
    }
}

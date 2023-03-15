using StateMachine;
using Ecs;

namespace Infrastructure.StateMachine
{
    public class LevelState : IState
    {
        private GameLoop _gameLoop;
        private Systems _systems;

        public LevelState(Systems systems, GameLoop gameCycle)
        {
            _gameLoop = gameCycle;
            _systems = systems;
        }

        public void Enter()
        {
            _gameLoop.OnFixedTick += FixedTick;
            _gameLoop.OnTick += Tick;
        }

        public void Exit()
        {
            _gameLoop.OnFixedTick -= FixedTick;
            _gameLoop.OnTick -= Tick;
        }

        private void FixedTick(float deltaTime)
            => _systems.FixedTick(deltaTime);

        private void Tick(float deltaTime)
            => _systems.Tick(deltaTime);
    }
}
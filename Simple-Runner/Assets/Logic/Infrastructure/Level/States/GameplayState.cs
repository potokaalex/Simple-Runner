using StateMachines;
using Ecs;

namespace Infrastructure
{
    public class GameplayState : IState
    {
        private IGameLoop _gameLoop;
        private Systems _systems;

        public GameplayState(IGameLoop gameLoop, DataProvider data)
        {
            _gameLoop = gameLoop;
            _systems = data.Systems;
        }

        public void Enter()
        {
            _gameLoop.OnFixedTick += _systems.FixedTick;
            _gameLoop.OnTick += _systems.Tick;
        }

        public void Exit()
        {
            _gameLoop.OnFixedTick -= _systems.FixedTick;
            _gameLoop.OnTick -= _systems.Tick;
        }
    }
}

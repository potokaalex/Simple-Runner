using StateMachine;
using Ecs;

namespace Infrastructure.StateMachine
{
    public class LevelState : IState
    {
        private GameCycle _gameCycle;
        private Systems _systems;

        public LevelState(Systems systems, GameCycle gameCycle)
        {
            _gameCycle = gameCycle;
            _systems = systems;
        }

        public void Enter()
        {
            _gameCycle.OnFixedTick += FixedTick;
            _gameCycle.OnTick += Tick;
        }

        public void Exit()
        {
            _gameCycle.OnFixedTick -= FixedTick;
            _gameCycle.OnTick -= Tick;
        }

        private void FixedTick(float deltaTime)
            => _systems.FixedTick(deltaTime);

        private void Tick(float deltaTime)
            => _systems.Tick(deltaTime);
    }
}
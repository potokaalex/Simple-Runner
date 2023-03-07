using UnityEngine.SceneManagement;
using MovementSystem;
using RoadGeneration;
using StateMachine;
using UnityEngine;
using InputSystem;
using DeathSystem;
using Ecs;
using Zenject;

namespace StateMachine
{
    public class GameLevelState : IState
    {
        private GlobalStateMachine _stateMachine;
        private ISceneLoader _sceneLoader;

        private GameCycle _gameCycle;
        [Inject] private GameLevelSettings _settings;

        public GameLevelState(GameLevelSettings settings, GameCycle gameCycle)
        {
            //_stateMachine = stateMachine;
            //_sceneLoader = sceneLoader;
            _settings = settings;
            _gameCycle = gameCycle;
            //_settings = settings;
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
        {
            _settings.FixedTickableSystems.Update(deltaTime);
        }

        private void Tick(float deltaTime)
        {
            _settings.TickableSystems.Update(deltaTime);
        }
    }
}
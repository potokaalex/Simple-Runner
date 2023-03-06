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
        private IGlobalStateMachine _stateMachine;
        private ISceneLoader _sceneLoader;

        private GameCycle _gameCycle;
        [Inject] private GameLevelSettings _settings;

        public GameLevelState(IGlobalStateMachine stateMachine, ISceneLoader sceneLoader, GameCycle gameCycle)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameCycle = gameCycle;
            //_settings = settings;
        }

        public void Enter()
        {
            //_gameCycle.OnFixedTick += FixedTick;
            //_gameCycle.OnTick += Tick;
        }

        public void Exit()
        {
            _gameCycle.OnFixedTick -= FixedTick;
            _gameCycle.OnTick -= Tick;
        }


        private void FixedTick(float deltaTime)
        {
            //Debug.Log()

            _settings.FixedTickableSystems.Update(deltaTime);
        }

        private void Tick(float deltaTime)
        {
            _settings.TickableSystems.Update(deltaTime);
        }
    }
}
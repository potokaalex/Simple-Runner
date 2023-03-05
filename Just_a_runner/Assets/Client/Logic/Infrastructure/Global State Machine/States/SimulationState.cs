using UnityEngine.SceneManagement;
using MovementSystem;
using RoadGeneration;
using StateMachine;
using UnityEngine;
using InputSystem;
using DeathSystem;
using Ecs;

namespace StateMachine
{
    public class SimulationState : IState
    {
        private const string SimulationScene = "Simulation";

        private IGlobalStateMachine _stateMachine;
        private ISceneLoader _sceneLoader;

        public SimulationState(IGlobalStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            //загрузка игрового уровня
            _sceneLoader.LoadScene(SimulationScene, LoadSceneMode.Single);
            _stateMachine.SwitchTo<SimulationState>();


            _fixedUpdateSystems
            .Add(Core())

            .Add(new RoadGenerator(CharacterMarker, RoadData))
            .Add(new DeathHandler(CharacterMarker))

            .Add(Movement());

            _updateSystems
                .Add(new InputUpdate());
        }

        public void Exit() { }

        private void Update()
        {
            //if (PauseManager.IsPaused)
            //    return;

            _updateSystems.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            //if (PauseManager.IsPaused)
            //    return;

            _fixedUpdateSystems.Update(Time.fixedDeltaTime);
        }

        private Systems Movement()
            => new Systems()
            .Add(new MoveRightUpdate())
            .Add(new MoveLeftUpdate())
            .Add(new RunUpdate());

        private Systems Core()
            => new Systems()
            .Add(new EntitiesUpdate())
            .Add(new EventsRemove());
    }
}
using MovementSystem;
using RoadGeneration;
using StateMachine;
using UnityEngine;
using InputSystem;
using DeathSystem;
using Ecs;

namespace GlobalStateMachine
{
    public class SimulationState : IState
    {
        public CharacterMarker CharacterMarker;
        public RoadData RoadData;

        private Systems _updateSystems = new();
        private Systems _fixedUpdateSystems = new();

        public void Enter()
        {
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
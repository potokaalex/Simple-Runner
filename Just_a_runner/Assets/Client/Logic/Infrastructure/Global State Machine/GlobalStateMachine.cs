using System;
using System.Collections.Generic;
using StateMachine;

namespace StateMachine
{
    public class GlobalStateMachine : IGlobalStateMachine, Zenject.IInitializable
    {
        private Dictionary<Type, IState> _states = new();
        private IStateFactory _factory;
        private IState _currentState;

        public GlobalStateMachine(IStateFactory factory)
        {
            _factory = factory;
        }

        public void Initialize()
        {
            _states.Add(typeof(MainMenuState), _factory.Create<MainMenuState>());
            _states.Add(typeof(SimulationState), _factory.Create<SimulationState>());
            _states.Add(typeof(PauseState), _factory.Create<PauseState>());
            _states.Add(typeof(DefeatState), _factory.Create<DefeatState>());

            _currentState = _states[typeof(MainMenuState)];
            _currentState.Enter();
        }

        public void SwitchTo<StateType>() where StateType : IState
        {
            _currentState?.Exit(); // 
            _currentState = _states[typeof(StateType)];
            _currentState.Enter();
        }
    }
}
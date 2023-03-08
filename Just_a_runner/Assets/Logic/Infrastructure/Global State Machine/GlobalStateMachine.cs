using System.Collections.Generic;
using StateMachine;
using System;

namespace Infrastructure.StateMachine
{
    public class GlobalStateMachine
    {
        private Dictionary<Type, IState> _states = new();
        private IState _currentState;

        public void Add(IState state)
        {
            _states.Add(state.GetType(), state);
        }

        public void SwitchTo<StateType>() where StateType : IState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(StateType)];
            _currentState.Enter();
        }
    }
}
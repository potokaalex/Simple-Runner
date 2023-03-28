using System.Collections.Generic;
using System;

namespace StateMachines
{
    public class StateMachine : IStateMachine
    {
        private Dictionary<Type, IState> _states = new();
        private IStateFactory _factory;
        private IState _currentState;

        public StateMachine(IStateFactory factory)
            => _factory = factory;

        public void SwitchTo<StateType>() where StateType : IState
        {
            _currentState?.Exit();
            _currentState = GetState<StateType>();
            _currentState.Enter();
        }

        private IState GetState<StateType>() where StateType : IState
        {
            var stateType = typeof(StateType);

            if (!_states.ContainsKey(stateType))
                _states.Add(stateType, _factory.Create<StateType>());

            return _states[stateType];
        }
    }
}

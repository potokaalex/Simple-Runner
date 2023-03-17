using System.Collections.Generic;
using StateMachine;
using System;

namespace Infrastructure.StateMachine
{
    public class GlobalStateMachine
    {
        private Dictionary<Type, IState> _states = new();
        private StateFactory _stateFactory;
        private IState _currentState;

        public GlobalStateMachine(StateFactory stateFactory)
        {
            _stateFactory = stateFactory;
            UnityEngine.Debug.Log("GlobalStateMachine created!");
        }

        public void Add(IState state)
        {
            var stateType = state.GetType();

            if (_states.ContainsKey(stateType))
                _states[stateType] = state;
            else
                _states.Add(stateType, state);
        }

        public void SwitchTo<StateType>() where StateType : IState
        {
            _currentState?.Exit();
            _currentState = GetState<StateType>(); //_states[typeof(StateType)];
            _currentState.Enter();
        }

        private IState GetState<StateType>() where StateType : IState
        {
            return _stateFactory.Create<StateType>();
            //return default;
        }
    }
}
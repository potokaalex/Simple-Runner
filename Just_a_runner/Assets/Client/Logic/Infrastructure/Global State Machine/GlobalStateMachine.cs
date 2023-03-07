using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace StateMachine
{
    public class GlobalStateMachine
    {
        private Dictionary<Type, IState> _states = new();
        private IStateFactory _factory;
        private IState _currentState;

        public GlobalStateMachine(IStateFactory factory)
        {
            _factory = factory;
        }

        //public void Initialize()
        //   => SwitchTo<MainMenuState>();

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
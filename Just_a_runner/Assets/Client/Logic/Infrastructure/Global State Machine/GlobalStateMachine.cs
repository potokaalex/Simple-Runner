using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

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
            _states.Add(typeof(MainMenuState), _currentState = _factory.Create<MainMenuState>());

            _currentState.Enter();
        }

        public void SwitchTo<StateType>() where StateType : IState
        {
            _currentState?.Exit();
            _currentState = GetState<StateType>();
            _currentState.Enter();
        }

        private IState GetState<StateType>() where StateType : IState
        {
            var stateType = typeof(StateType);

            if (typeof(GameLevelState) == stateType)
                Debug.Log("GameLevelState CREATED");

            if (!_states.ContainsKey(stateType))
                _states.Add(stateType, _factory.Create<StateType>());

            return _states[stateType];
        }
    }
}
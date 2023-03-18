using System.Collections.Generic;
using StateMachine;
using System;

namespace Infrastructure
{
    public class GlobalStateMachine
    {
        private Dictionary<Type, IState> _states = new();
        private List<IStateFactory> _factories = new();
        private IState _currentState;

        public GlobalStateMachine(IStateFactory defaultFactory)
            => AddFactory(defaultFactory);

        public void AddFactory(IStateFactory factory)
        {
            if (!_factories.Contains(factory))
                _factories.Add(factory);
        }

        public void SwitchTo<StateType>() where StateType : IState
        {
            var stateType = typeof(StateType);

            _currentState?.Exit();
            //
            if (!_states.ContainsKey(stateType))
                _currentState = Create<StateType>();
            else
                _currentState = _states[stateType];
            //
            _currentState.Enter();
        }

        private StateType Create<StateType>() where StateType : IState
        {
            foreach (var factory in _factories)
            {
                try
                {
                    return factory.Create<StateType>();
                }
                catch
                {
                    continue;
                }
            }

            throw new Exception($"The {typeof(StateType).Name}" +
                "cannot be created by known factories, use AddFactory to avoid this.");
        }
    }
}
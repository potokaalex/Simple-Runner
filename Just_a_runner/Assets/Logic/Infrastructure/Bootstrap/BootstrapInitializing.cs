﻿using Infrastructure.StateMachine;
using StateMachine;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInitializing : IInitializable
    {
        private GlobalStateMachine _stateMachine;
        private StateFactory _stateFactory;

        public BootstrapInitializing(GlobalStateMachine stateMachine, StateFactory stateFactory)
        {
            _stateFactory = stateFactory;
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            _stateMachine.Add(_stateFactory.Create<LevelLoadingState>());
            _stateMachine.Add(_stateFactory.Create<MainMenuState>());

            _stateMachine.SwitchTo<MainMenuState>();
        }
    }
}
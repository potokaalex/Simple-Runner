using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;
using Ecs;
using System;
using StateMachine;

namespace GlobalStateMachine
{
    public class BootstrapState : IState
    {
        private const string MainMenuScene = "MainMenu";

        private IGlobalStateMachine _stateMachine;
        private ISceneLoader _sceneLoader;

        public BootstrapState(IGlobalStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(MainMenuScene, LoadSceneMode.Single);
            _stateMachine.SwitchTo<MainMenuState>();
        }

        public void Exit() { }
    }
}
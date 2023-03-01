using UnityEngine.AddressableAssets;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;
using Ecs;
using System;

public class BootstrapState : IState
{
    private IGlobalStateMachine _stateMachine;
    private AssetReference _mainMenuScene;
    private SceneLoader _sceneLoader;

    [Serializable]
    public class Settings
    {
        public AssetReference MainMenuScene;
    }

    public BootstrapState(IGlobalStateMachine stateMachine, SceneLoader sceneLoader, Settings settings)
    {
        _mainMenuScene = settings.MainMenuScene;
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
        _sceneLoader.LoadScene(_mainMenuScene, LoadSceneMode.Additive,
            _stateMachine.SwitchTo<LoadingState>);
    }

    public void Exit() { }
}

public class LoadingState : IState
{
    public void Enter() { }

    public void Exit() { }
}
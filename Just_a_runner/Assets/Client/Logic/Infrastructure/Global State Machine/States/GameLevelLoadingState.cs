using StateMachine;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace StateMachine
{
    public class GameLevelLoadingState : IState
    {
        private const string GameLevelScene = "GameLevel";

        private ISceneLoader _sceneLoader;

        public GameLevelLoadingState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(GameLevelScene, LoadSceneMode.Single);
        }

        public void Exit() { }
    }
}
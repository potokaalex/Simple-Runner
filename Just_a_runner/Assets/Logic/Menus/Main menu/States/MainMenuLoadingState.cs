using UnityEngine.SceneManagement;
using StateMachine;

namespace MainMenu
{
    public class MainMenuLoadingState : IState
    {
        private const string MainMenuScene = "MainMenu";
        private ISceneLoader _sceneLoader;

        public MainMenuLoadingState(ISceneLoader sceneLoader)
            => _sceneLoader = sceneLoader;

        public void Enter()
            => _sceneLoader.LoadScene(MainMenuScene, LoadSceneMode.Single);
    }
}
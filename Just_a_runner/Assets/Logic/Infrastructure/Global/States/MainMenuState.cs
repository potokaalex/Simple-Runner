using UnityEngine.SceneManagement;
using StateMachine;

namespace Infrastructure
{
    public class MainMenuState : IState
    {
        private const string MainMenuScene = "MainMenu";
        private ISceneLoader _sceneLoader;

        public MainMenuState(ISceneLoader sceneLoader)
            => _sceneLoader = sceneLoader;

        public void Enter()
            => _sceneLoader.LoadScene(MainMenuScene, LoadSceneMode.Single);
    }
}
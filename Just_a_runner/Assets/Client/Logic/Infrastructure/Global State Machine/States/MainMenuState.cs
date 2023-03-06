using UnityEngine.SceneManagement;

namespace StateMachine
{
    public class MainMenuState : IState
    {
        private const string MainMenuScene = "MainMenu";

        private ISceneLoader _sceneLoader;

        public MainMenuState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(MainMenuScene, LoadSceneMode.Single);
        }

        public void Exit() { }
    }
}
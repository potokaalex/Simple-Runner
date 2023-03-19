using UnityEngine.SceneManagement;
using StateMachine;

namespace Infrastructure.Menus
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
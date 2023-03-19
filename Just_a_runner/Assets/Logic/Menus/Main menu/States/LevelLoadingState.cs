using UnityEngine.SceneManagement;
using StateMachine;

namespace MainMenu
{
    public class LevelLoadingState : IState
    {
        private const string LevelScene = "Level";
        private ISceneLoader _sceneLoader;

        public LevelLoadingState(ISceneLoader sceneLoader)
            => _sceneLoader = sceneLoader;

        public void Enter()
            => _sceneLoader.LoadScene(LevelScene, LoadSceneMode.Single);
    }
}
using UnityEngine.SceneManagement;
using StateMachine;

namespace Infrastructure.Menus
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
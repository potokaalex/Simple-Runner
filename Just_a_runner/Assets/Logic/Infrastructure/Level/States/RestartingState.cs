using UnityEngine.SceneManagement;
using StateMachine;

namespace Infrastructure
{
    public class RestartingState : IState
    {
        private const string LevelScene = "Level";
        private ISceneLoader _sceneLoader;

        public RestartingState(ISceneLoader sceneLoader)
            => _sceneLoader = sceneLoader;

        public void Enter()
            => _sceneLoader.LoadScene(LevelScene, LoadSceneMode.Single);
    }
}
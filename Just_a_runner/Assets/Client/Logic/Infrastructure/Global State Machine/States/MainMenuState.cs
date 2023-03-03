using UnityEngine.SceneManagement;

using StateMachine;

namespace GlobalStateMachine
{
    public class MainMenuState : IState
    {
        private const string GameScene = "Game";

        private IGlobalStateMachine _stateMachine;
        private ISceneLoader _sceneLoader;

        public MainMenuState(IGlobalStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() { }

        public void Exit()
        {
            //_sceneLoader.LoadSceneAsync(GameScene, LoadSceneMode.Single,
            //    _stateMachine.SwitchTo<MainMenuState>);
        }
    }
}
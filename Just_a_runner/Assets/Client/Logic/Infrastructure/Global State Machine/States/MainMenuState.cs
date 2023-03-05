using UnityEngine.SceneManagement;

namespace StateMachine
{
    public class MainMenuState : IState
    {
        private const string MainMenuScene = "MainMenu";

        private IGlobalStateMachine _stateMachine;
        private ISceneLoader _sceneLoader;

        public MainMenuState(IGlobalStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(MainMenuScene, LoadSceneMode.Single);
            _stateMachine.SwitchTo<SimulationState>();
        }

        public void Exit() { }
    }
}
using UnityEngine.SceneManagement;
using StateMachine;
using UnityEngine;
using MainMenu;
using Zenject;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private IState _initialState;

        [Inject]
        private void Constructor(ISceneLoader sceneLoader)
            => _initialState = new MainMenuLoadingState(sceneLoader);

        public void Start()
            => _initialState.Enter();
    }
}
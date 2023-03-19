using StateMachines;
using UnityEngine;
using Zenject;

namespace Infrastructure.Menus
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject Window;
        [SerializeField] private GameObject ActivateButton;
        private IStateMachine _stateMachine;

        [Inject]
        private void Construcor(IStateMachine stateMachine)
            => _stateMachine = stateMachine;

        public void Open()
            => Window.SetActive(true);

        public void Close()
            => Window.SetActive(false);

        public void ShowActivateButton()
            => ActivateButton.SetActive(true);

        public void HideActivateButton()
            => ActivateButton.SetActive(false);

        public void Pause()
            => _stateMachine.SwitchTo<PauseState>();

        public void Restart()
            => _stateMachine.SwitchTo<RestartingState>();

        public void Resume()
            => _stateMachine.SwitchTo<GameplayState>();
    }
}
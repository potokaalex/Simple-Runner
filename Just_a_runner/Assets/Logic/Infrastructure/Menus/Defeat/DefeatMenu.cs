using StateMachines;
using UnityEngine;
using Zenject;
using TMPro;

namespace Infrastructure.Menus
{
    public class DefeatMenu : MonoBehaviour
    {
        [SerializeField] private GameObject Window;
        [SerializeField] private TextMeshProUGUI _currentScore;
        [SerializeField] private TextMeshProUGUI _maxScore;
        private IStateMachine _stateMachine;

        [Inject]
        private void Construcor(IStateMachine stateMachine)
            => _stateMachine = stateMachine;

        public void SetCurrentScore(uint score)
            => _currentScore.text = score.ToString();

        public void SetMaxScore(uint score)
            => _maxScore.text = score.ToString();

        public void Open()
            => Window.SetActive(true);

        public void Close()
            => Window.SetActive(false);

        public void Restart()
            => _stateMachine.SwitchTo<RestartingState>();

        public void Menu()
            => _stateMachine.SwitchTo<MainMenuLoadingState>();
    }
}
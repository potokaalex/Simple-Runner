using StateMachine;
using Statistics;

namespace Infrastructure.Menus
{
    public class DefeatState : IState
    {
        private DefeatMenu _defeatMenu;
        private PauseMenu _pauseMenu;
        private CharacterScore _score;
        private ScoreIndicator _scoreIndicator;

        public DefeatState(
            DefeatMenu defeatMenu,
            PauseMenu pauseMenu,
            CharacterScore score,
            ScoreIndicator scoreIndicator)
        {
            _defeatMenu = defeatMenu;
            _pauseMenu = pauseMenu;
            _score = score;
            _scoreIndicator = scoreIndicator;
        }

        public void Enter()
        {
            _defeatMenu.SetCurrentScore(_score.CurrentScore);
            _defeatMenu.SetMaxScore(_score.GetMaxScore());
            _defeatMenu.Open();

            _pauseMenu.HideActivateButton();
            _scoreIndicator.Hide();
        }
    }
}
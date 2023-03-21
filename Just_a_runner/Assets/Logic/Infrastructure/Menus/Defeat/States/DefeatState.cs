using StateMachines;
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
            StatisticsData statisticsData,
            ScoreIndicator scoreIndicator)
        {
            _defeatMenu = defeatMenu;
            _pauseMenu = pauseMenu;
            _score = statisticsData.CharacterScore;
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

        public void Exit()
        {
            _defeatMenu.Close();
            _scoreIndicator.Show();
            _pauseMenu.ShowActivateButton();
        }
    }
}
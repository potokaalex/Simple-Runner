using StateMachine;
using Statistics;

namespace Infrastructure
{
    public class DefeatState : IState
    {
        private DefeatMenu _defeatMenu;
        private CharacterScore _score;
        private ScoreIndicator _scoreIndicator;

        public DefeatState(
            DefeatMenu defeatMenu,
            CharacterScore score,
            ScoreIndicator scoreIndicator)
        {
            _defeatMenu = defeatMenu;
            _score = score;
            _scoreIndicator = scoreIndicator;
        }

        public void Enter()
        {
            _defeatMenu.SetCurrentScore(_score.CurrentScore);
            _defeatMenu.SetMaxScore(_score.GetMaxScore());
            _defeatMenu.Open();

            _scoreIndicator.Hide();
        }
    }
}
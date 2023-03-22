using StateMachines;
using Character;

namespace Infrastructure.Menus
{
    public class DefeatState : IState
    {
        private DefeatMenu _defeatMenu;
        private PauseMenu _pauseMenu;
        private Score _score;

        public DefeatState(DataProvider data)
        {
            _defeatMenu = data.DefeatMenu;
            _pauseMenu = data.PauseMenu;
            _score = data.CharacterData.Score;
        }

        public void Enter()
        {
            _defeatMenu.SetCurrentScore(_score.CurrentScore);
            _defeatMenu.SetMaxScore(_score.GetMaxScore());
            _defeatMenu.Open();

            _pauseMenu.HideActivateButton();
            _score.CurrentScore = new(0);
        }

        public void Exit()
        {
            _defeatMenu.Close();
            _pauseMenu.ShowActivateButton();
        }
    }
}

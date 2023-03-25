using StateMachines;

namespace Infrastructure.Menus
{
    public class PauseState : IState
    {
        private PauseMenu _pauseMenu;

        public PauseState(DataProvider data)
            => _pauseMenu = data.PauseMenu;

        public void Enter()
        {
            _pauseMenu.HideActivateButton();
            _pauseMenu.Open();
        }

        public void Exit()
        {
            _pauseMenu.ShowActivateButton();
            _pauseMenu.Close();
        }
    }
}

using StateMachines;

namespace Infrastructure.Menus
{
    public class PauseState : IState
    {
        private PauseMenu _pauseMenu;

        public PauseState(PauseMenu pauseMenu)
            => _pauseMenu = pauseMenu;

        public void Enter()
            => _pauseMenu.Open();

        public void Exit()
            => _pauseMenu.Close();
    }
}
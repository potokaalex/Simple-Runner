using StateMachine;

namespace Infrastructure.StateMachine
{
    public class DefeatState : IState
    {
        private DefeatMenu _defeatMenu;

        public DefeatState(DefeatMenu defeatMenu) 
        {
            _defeatMenu = defeatMenu;
        }

        public void Enter()
        {
            _defeatMenu.Open();
        }

        public void Exit() { }
    }
}
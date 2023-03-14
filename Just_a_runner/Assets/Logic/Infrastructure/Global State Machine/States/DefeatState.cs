using StateMachine;
using Statistics;

namespace Infrastructure.StateMachine
{
    public class DefeatState : IState
    {
        private DefeatMenu _defeatMenu;
        private CharacterScore _score;

        public DefeatState(DefeatMenu defeatMenu,CharacterScore score)
        {
            _defeatMenu = defeatMenu;
            _score = score;
        }

        public void Enter()
        {
            _defeatMenu.SetCurrentScore(_score.Score);
            //_defeatMenu.SetMaxScore(_score.Score);

            _defeatMenu.Open();
        }

        public void Exit() { }
    }

    //нужно написатб плагин сохранения 
}
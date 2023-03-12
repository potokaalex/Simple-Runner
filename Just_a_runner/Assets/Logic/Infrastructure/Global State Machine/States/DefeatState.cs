using StateMachine;

namespace Infrastructure.StateMachine
{
    public class DefeatState : IState
    {
        private CharacterMarker _character;
        private DefeatMenu _defeatMenu;

        public DefeatState(CharacterMarker character, DefeatMenu defeatMenu)
        {
            _character = character;
            _defeatMenu = defeatMenu;
        }

        public void Enter()
        {
            _defeatMenu.SetScore((int)_character.transform.position.z - 20);
            _defeatMenu.Open();
        }

        public void Exit() { }
    }
}
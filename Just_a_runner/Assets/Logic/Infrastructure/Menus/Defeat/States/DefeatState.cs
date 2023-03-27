using StateMachines;
using InputService;
using Character;
using Ecs;

namespace Infrastructure.Menus
{
    public class DefeatState : IState
    {
        private DefeatMenu _defeatMenu;
        private PauseMenu _pauseMenu;
        private Score _score;

        private IStateMachine _stateMachine;
        private IGameLoop _gameLoop;

        public DefeatState(DataProvider data, IGameLoop gameLoop, IStateMachine stateMachine)
        {
            _defeatMenu = data.DefeatMenu;
            _pauseMenu = data.PauseMenu;
            _score = data.CharacterData.Score;

            _stateMachine = stateMachine;
            _gameLoop = gameLoop;
        }

        public void Enter()
        {
            _defeatMenu.SetCurrentScore(_score.CurrentScore);
            _defeatMenu.SetMaxScore(_score.GetMaxScore());
            _defeatMenu.Open();

            _pauseMenu.HideActivateButton();
            _score.CurrentScore = new(0);

            _gameLoop.OnFixedTick += FixedTick;
        }

        public void Exit()
        {
            _defeatMenu.Close();
            _pauseMenu.ShowActivateButton();

            _gameLoop.OnFixedTick -= FixedTick;
        }

        private void FixedTick(float deltaTime)
        {
            if (World.Events.Contains<RestartKey>())
                _stateMachine.SwitchTo<RestartingState>();
        }
    }
}

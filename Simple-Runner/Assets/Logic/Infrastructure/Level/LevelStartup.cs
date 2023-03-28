using StateMachines;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        private SystemsInitialization _systemsInitialization;
        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(IStateMachine stateMachine, SystemsInitialization systemsInitialization)
        {
            _systemsInitialization = systemsInitialization;
            _stateMachine = stateMachine;
        }

        private void Start()
        {
            _systemsInitialization.Initialize();
            _stateMachine.SwitchTo<GameplayState>();
        }
    }
}

using StateMachine;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        private GlobalStateMachine _stateMachine;
        private IStateFactory _stateFactory;

        [Inject]
        private void Constructor(GlobalStateMachine stateMachine, IStateFactory stateFactory)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
        }

        private void Start()
        {
            Debug.Log("Startup !");

            _stateMachine.AddFactory(_stateFactory);
            _stateMachine.SwitchTo<LevelState>();
        }
    }
}
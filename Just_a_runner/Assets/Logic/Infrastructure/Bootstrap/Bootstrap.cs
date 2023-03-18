using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private GlobalStateMachine _stateMachine;

        [Inject]
        private void Constructor(GlobalStateMachine stateMachine)
            => _stateMachine = stateMachine;

        private void Start()
            => _stateMachine.SwitchTo<MainMenuState>();
    }
}
using StateMachines;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        [Inject]
        private void Constructor(IStateMachine stateMachine)
            => stateMachine.SwitchTo<GameplayState>();
    }
}
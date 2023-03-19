using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        [Inject]
        private void Constructor(StateMachine stateMachine)
            => stateMachine.SwitchTo<GameplayState>();
    }
}
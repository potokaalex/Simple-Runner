using Infrastructure.Menus;
using StateMachines;
using UnityEngine;
using Zenject;

public class AutoPause : MonoBehaviour
{
    private IStateMachine _stateMachine;

    [Inject]
    private void Construcor(IStateMachine stateMachine)
        => _stateMachine = stateMachine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            _stateMachine.SwitchTo<PauseState>();
    }
}
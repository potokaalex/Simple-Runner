using Infrastructure;
using StateMachines;
using UnityEngine;
using Zenject;

public class AutoRestart : MonoBehaviour
{
    private IStateMachine _stateMachine;

    [Inject]
    private void Construcor(IStateMachine stateMachine)
        => _stateMachine = stateMachine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _stateMachine.SwitchTo<RestartingState>();
    }
}
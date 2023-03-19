using Infrastructure;
using UnityEngine;
using Zenject;

public class AutoRestart : MonoBehaviour
{
    private Infrastructure.StateMachine _stateMachine;

    [Inject]
    private void Construcor(Infrastructure.StateMachine stateMachine)
        => _stateMachine = stateMachine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _stateMachine.SwitchTo<RestartingState>();
    }
}
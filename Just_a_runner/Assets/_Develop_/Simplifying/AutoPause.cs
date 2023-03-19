using Infrastructure.Menus;
using UnityEngine;
using Zenject;

public class AutoPause : MonoBehaviour
{
    private Infrastructure.StateMachine _stateMachine;

    [Inject]
    private void Construcor(Infrastructure.StateMachine stateMachine)
        => _stateMachine = stateMachine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            _stateMachine.SwitchTo<PauseState>();
    }
}
using UnityEngine.SceneManagement;
using UnityEngine;
using Zenject;
using UnityEditor;
using StateMachine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AboutAnimation _aboutAnimation;

    private IGlobalStateMachine _stateMachine;

    [Inject]
    private void Construcor(IGlobalStateMachine stateMachine)
        => _stateMachine = stateMachine;

    public void Play()
        => _stateMachine.SwitchTo<SimulationState>();

    public void AboutToggle()
        => _aboutAnimation.AnimationToggle();

    public void Exit()
#if UNITY_EDITOR
        => EditorApplication.isPlaying = false;
#else
        => Application.Quit();
#endif
}
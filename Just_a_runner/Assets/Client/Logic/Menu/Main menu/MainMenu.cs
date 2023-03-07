using UnityEngine.SceneManagement;
using UnityEngine;
using Zenject;
using UnityEditor;
using StateMachine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AboutAnimation _aboutAnimation;

    private GlobalStateMachine _stateMachine;

    [Inject]
    private void Construcor(GlobalStateMachine stateMachine)
        => _stateMachine = stateMachine;

    public void Play()
        => _stateMachine.SwitchTo<GameLevelLoadingState>();

    public void AboutToggle()
        => _aboutAnimation.AnimationToggle();

    public void Exit()
#if UNITY_EDITOR
        => EditorApplication.isPlaying = false;
#else
        => Application.Quit();
#endif
}
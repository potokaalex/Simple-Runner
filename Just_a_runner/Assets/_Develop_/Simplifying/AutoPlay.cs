using UnityEngine.SceneManagement;
using Infrastructure.Menus;
using StateMachine;
using UnityEngine;
using Zenject;

public class AutoPlay : MonoBehaviour
{
    private IState _playingState;

    [Inject]
    private void Construcor(ISceneLoader sceneLoader)
        => _playingState = new LevelLoadingState(sceneLoader);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            _playingState.Enter();
    }
}
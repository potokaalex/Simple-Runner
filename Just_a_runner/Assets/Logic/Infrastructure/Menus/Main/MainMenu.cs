using UnityEngine.SceneManagement;
using StateMachine;
using UnityEngine;
using UnityEditor;
using Zenject;

namespace Infrastructure.Menus
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private AboutAnimation _aboutAnimation;
        private IState _playingState;

        [Inject]
        private void Construcor(ISceneLoader sceneLoader)
            => _playingState = new LevelLoadingState(sceneLoader);

        public void Play()
                => _playingState.Enter();

        public void AboutToggle()
            => _aboutAnimation.AnimationToggle();

        public void Exit()
#if UNITY_EDITOR
        => EditorApplication.isPlaying = false;
#else
        => Application.Quit();
#endif
    }
}
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine;
using Zenject;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AboutAnimation _aboutAnimation;
    [SerializeField] private AssetReference _gameScene;

    private SceneLoader _sceneLoader;

    [Inject]
    private void Construcor(SceneLoader sceneLoader)
        => _sceneLoader = sceneLoader;

    public void Play()
        => _sceneLoader.LoadScene(_gameScene, LoadSceneMode.Single);

    public void AboutToggle()
        => _aboutAnimation.AnimationToggle();

    public void Exit()
        => Application.Quit();
}
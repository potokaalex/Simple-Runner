using UnityEngine.AddressableAssets;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private AssetReference _mainMenuScene;

    private SceneLoader _sceneLoader;

    [Inject]
    private void Construcor(SceneLoader sceneLoader)
        => _sceneLoader = sceneLoader;

    private void Awake() => _sceneLoader.LoadScene(_mainMenuScene, LoadSceneMode.Additive);
}
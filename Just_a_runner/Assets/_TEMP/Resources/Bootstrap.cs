using UnityEngine.AddressableAssets;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;
using Ecs;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private AssetReference _mainMenuScene;

    private SceneLoader _sceneLoader;

    [Inject]
    private void Construcor(SceneLoader sceneLoader)
        => _sceneLoader = sceneLoader;

    private void Awake() => _sceneLoader.LoadScene(_mainMenuScene, LoadSceneMode.Additive);
}

public class BootstrapState : IState
{
    public BootstrapState()
    {
        Debug.Log("BootstrapState - CREATED");
    }

    public void Enter()
    {
        Debug.Log("Enter");
    }

    public void Exit()
    {
        Debug.Log("Exit");
    }
}
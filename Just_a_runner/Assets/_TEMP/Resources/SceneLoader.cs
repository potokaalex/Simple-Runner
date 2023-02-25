using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using System;

public class SceneLoader
{
    public event Action OnLoadingStart;
    public event Action OnLoadingEnd;

    public async void LoadScene(AssetReference scene, LoadSceneMode loadMode, Action afterLoading = null)
    {
        var operationHandle = scene.LoadSceneAsync(loadMode);
        OnLoadingStart?.Invoke();

        await operationHandle.Task;

        OnLoadingEnd?.Invoke();
        afterLoading?.Invoke();
    }

    public void UnLoadScene(Scene scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
}
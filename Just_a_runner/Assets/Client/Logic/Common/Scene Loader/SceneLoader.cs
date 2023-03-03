using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

public interface ISceneLoader
{
    public event Action<AsyncOperation> OnLoadingStart;
    public event Action<AsyncOperation> OnLoadingEnd;

    public void LoadSceneAsync(string sceneName, LoadSceneMode loadMode, Action afterLoading);

    public void LoadScene(string sceneName, LoadSceneMode loadMode);
}

public class SceneLoader : ISceneLoader
{
    public event Action<AsyncOperation> OnLoadingStart;
    public event Action<AsyncOperation> OnLoadingEnd;

    public void LoadSceneAsync(string sceneName, LoadSceneMode loadMode, Action afterLoading = null)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneName, loadMode);

        OnLoadingStart?.Invoke(asyncOperation);

        asyncOperation.completed += (o) => OnLoadingEnd?.Invoke(o);
        asyncOperation.completed += (o) => afterLoading?.Invoke();
    }

    public void LoadScene(string sceneName, LoadSceneMode loadMode)
    {
        SceneManager.LoadScene(sceneName, loadMode);
    }
}
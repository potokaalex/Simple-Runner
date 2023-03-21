using System;

namespace UnityEngine.SceneManagement
{
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
    }
}
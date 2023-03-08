using System;

namespace UnityEngine.SceneManagement
{
    public interface ISceneLoader
    {
        public event Action<AsyncOperation> OnLoadingStart;
        public event Action<AsyncOperation> OnLoadingEnd;

        public void LoadSceneAsync(string sceneName, LoadSceneMode loadMode, Action afterLoading);

        public void LoadScene(string sceneName, LoadSceneMode loadMode);
    }
}
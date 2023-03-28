using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneLoader();
            BindGameLoop();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void BindGameLoop()
        {
            Container
                .Bind<IGameLoop>()
                .To<GameLoop>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}

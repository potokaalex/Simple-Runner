using Infrastructure.StateMachine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGlobalStateMachine();
            BindSceneLoader();
            BindGameCycle();
        }

        private void BindGlobalStateMachine()
        {
            Container
                .Bind<GlobalStateMachine>()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void BindGameCycle()
        {
            Container
                .Bind<GameLoop>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}
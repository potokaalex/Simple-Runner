using Infrastructure.StateMachine;
using UnityEngine.SceneManagement;
using Zenject;
using StateMachine;

namespace Infrastructure.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGlobalStateMachine();
            BindStateFactory();
            BindSceneLoader();
            BindGameLoop();
        }

        private void BindGlobalStateMachine()
        {
            Container
                .Bind<GlobalStateMachine>()
                .AsSingle();
        }

        private void BindStateFactory()
        {
            Container
                .Bind<StateFactory>()
                .AsSingle()
                .NonLazy();
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
                .Bind<GameLoop>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}
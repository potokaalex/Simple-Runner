using UnityEngine.SceneManagement;
using StateMachine;
using Zenject;

namespace Infrastructure.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings() //INPUT
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
                .Bind<IStateFactory>()
                .To<StateFactory>()
                .AsSingle();
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
using Infrastructure.StateMachine;
using UnityEngine.SceneManagement;
using StateMachine;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGlobalStateMachineInitialization();
            BindGlobalStateMachine();
            BindStateFactory();
            BindSceneLoader();
            BindGameCycle();
        }

        private void BindGlobalStateMachineInitialization()
        {
            Container
                .BindInterfacesAndSelfTo<GlobalStateMachineInitialization>()
                .AsSingle();
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
                .Bind<GameCycle>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}
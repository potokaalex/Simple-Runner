using StateMachines;
using InputService;
using UnityEngine;
using Zenject;
using Ecs;

namespace Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private DataProvider _data;

        public override void InstallBindings()
        {
            BindSystemsInitialization();
            BindSystemsFactory();
            BindStateMachine();
            BindDataProvider();
            BindInputService();
            EntitiesUpdateService();
        }

        private void BindSystemsInitialization()
        {
            Container
                .Bind<SystemsInitialization>()
                .AsSingle();
        }

        private void BindSystemsFactory()
        {
            Container
                .Bind<SystemsFactory>()
                .AsSingle();
        }

        private void BindStateMachine()
        {
            Container
                .Bind<IStateMachine>()
                .FromInstance(new StateMachine(new StateFactory(Container)))
                .AsSingle();
        }

        private void BindDataProvider()
        {
            Container
                .Bind<DataProvider>()
                .FromInstance(_data)
                .AsSingle();
        }

        private void BindInputService()
        {
            Container
                .BindInterfacesAndSelfTo<KeyboardInput>()
                .AsSingle();
        }

        private void EntitiesUpdateService()
        {
            Container
                .BindInterfacesAndSelfTo<EntitiesUpdate>()
                .AsSingle();
        }
    }
}

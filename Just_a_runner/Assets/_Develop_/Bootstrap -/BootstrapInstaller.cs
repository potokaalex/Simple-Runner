using StateMachine;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBootstrapInitializing();
            BindStateFactory();
        }

        private void BindBootstrapInitializing()
        {
            Container
                .BindInterfacesAndSelfTo<BootstrapInitializing>()
                .AsSingle();
        }

        private void BindStateFactory()
        {
            Container
                .Bind<StateFactory>()
                .AsSingle();
        }
    }
}
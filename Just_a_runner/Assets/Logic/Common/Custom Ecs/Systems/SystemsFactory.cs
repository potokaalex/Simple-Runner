using Zenject;

namespace Ecs
{
    public class SystemsFactory
    {
        private IInstantiator _instantiator;

        public SystemsFactory(IInstantiator instantiator)
            => _instantiator = instantiator;

        public SystemType Create<SystemType>() where SystemType : ISystem
            => _instantiator.Instantiate<SystemType>();
    }
}
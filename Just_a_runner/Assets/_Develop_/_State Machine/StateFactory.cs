using Zenject;

namespace StateMachine
{
    public class StateFactory : IStateFactory
    {
        private IInstantiator _instantiator;

        public StateFactory(IInstantiator instantiator)
            => _instantiator = instantiator;

        public StateType Create<StateType>() where StateType : IState
            => _instantiator.Instantiate<StateType>();
    }
}
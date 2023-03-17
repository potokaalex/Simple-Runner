using Zenject;

namespace StateMachine
{
    public class StateFactory
    {
        private IInstantiator _instantiator;

        public StateFactory(DiContainer instantiator)
        {
            _instantiator = instantiator;
            UnityEngine.Debug.Log("Factory created");
        }

        public StateType Create<StateType>() where StateType : IState
            => _instantiator.Instantiate<StateType>();
    }
}
using System;
using Zenject;
using UnityEngine;

namespace StateMachine
{
    public class StateFactory : IStateFactory//, IFactory<Type, IState>
    {
        private DiContainer _container;

        public StateFactory(DiContainer instantiator)
        {
            _container = instantiator;
        }

        public StateType Create<StateType>() where StateType : IState
        {
            //Debug.Log();

            return _container.Instantiate<StateType>();
        }

        //public IState Create(Type stateType)
        //{

        //}
    }
}
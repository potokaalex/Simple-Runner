//using ;

namespace StateMachine
{
    public interface IStateFactory
    {
        public StateType Create<StateType>() where StateType : IState;
    }
}
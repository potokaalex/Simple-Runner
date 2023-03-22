namespace StateMachines
{
    public interface IStateFactory
    {
        public StateType Create<StateType>() where StateType : IState;
    }
}

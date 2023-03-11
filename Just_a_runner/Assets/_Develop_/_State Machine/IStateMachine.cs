namespace StateMachine
{
    public interface IStateMachine
    {
        public void Add(IState state);
        public bool Remove(IState state);


        public void SwitchTo<StateType>() where StateType : IState;

        public void SwitchTo(IState state);
    }
}
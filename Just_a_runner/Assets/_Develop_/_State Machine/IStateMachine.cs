namespace StateMachine
{
    public interface IStateMachine
    {
        public void SwitchTo<StateType>() where StateType : IState;
    }
}
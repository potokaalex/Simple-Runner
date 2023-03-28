namespace Ecs
{
    public interface IFixedTickable : ISystem
    {
        public void FixedTick(float deltaTime);
    }
}

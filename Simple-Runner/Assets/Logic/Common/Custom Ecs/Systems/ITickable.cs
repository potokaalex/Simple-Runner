namespace Ecs
{
    public interface ITickable : ISystem
    {
        public void Tick(float deltaTime);
    }
}

namespace Ecs
{
    public interface IInitializationSystem : ISystem
    {
        public void Initialize();
    }
}
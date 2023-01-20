namespace Ecs
{
    public interface IFixedUpdateSystem : ISystem
    {
        public void FixedUpdate(float deltaTime);
    }
}
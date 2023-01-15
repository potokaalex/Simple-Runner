namespace Ecs
{
    public interface IUpdateSystem : ISystem
    {
        public void Update(float deltaTime);
    }
}
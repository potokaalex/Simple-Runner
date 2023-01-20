namespace Ecs
{
    public interface ILateUpdateSystem : ISystem
    {
        public void LateUpdate(float deltaTime);
    }
}
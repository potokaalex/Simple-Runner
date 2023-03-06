namespace Ecs
{
    public interface ISystem { }

    //public interface IInitializable : ISystem
    //{
    //    public void Initialize();
    //}

    public interface ITickable : ISystem
    {
        public void Tick(float deltaTime);
    }

    public interface IDestroyable : ISystem
    {
        public void Destroy();
    }
}

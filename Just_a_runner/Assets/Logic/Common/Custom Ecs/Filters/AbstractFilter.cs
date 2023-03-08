namespace Ecs
{
    public abstract class Filter
    {
        public abstract void Add(Entity entity);

        public abstract void Remove(Entity entity);
    }
}

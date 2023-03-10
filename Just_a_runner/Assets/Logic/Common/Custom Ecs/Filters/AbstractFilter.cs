namespace Ecs
{
    public abstract class Filter
    {
        public abstract void Add(IComponent component);

        public abstract void Remove(IComponent component);
    }
}

namespace Ecs
{
    public class FiltersUpdate : ITickable
    {
        public void Tick(float deltaTime)
            => World.Filters.UpdateFilters();
    }
}
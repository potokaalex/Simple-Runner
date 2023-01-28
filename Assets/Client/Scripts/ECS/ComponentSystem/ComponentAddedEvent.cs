namespace Ecs
{
    public class ComponentAdded : IEvent
    {
        public EcsComponent Component;

        public ComponentAdded(EcsComponent component)
            => Component = component;
    }
}

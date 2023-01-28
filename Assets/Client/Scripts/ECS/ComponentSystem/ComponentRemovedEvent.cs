namespace Ecs
{
    public class ComponentRemoved : IEvent
    {
        public EcsComponent Component;

        public ComponentRemoved(EcsComponent component)
            => Component = component;
    }
}

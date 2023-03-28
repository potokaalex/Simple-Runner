namespace Ecs
{
    public class Filter<ComponentType1, ComponentType2>
        : Filter<ComponentType1, ComponentType2, IComponent>
        where ComponentType1 : IComponent
        where ComponentType2 : IComponent
    { }
}

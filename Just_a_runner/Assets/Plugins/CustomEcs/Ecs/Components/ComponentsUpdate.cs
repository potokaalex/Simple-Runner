using System.Runtime.CompilerServices;

namespace Ecs
{
    public class ComponentsUpdate : ITickable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Tick(float deltaTime)
        {
            foreach (var entity in World.Entities)
                entity.ComponentsUpdate();
        }
    }
}
using System.Collections.Generic;

namespace Ecs
{
    public static class World
    {
        public static List<Entity> Entities;
        public static Entity Events;
        private static Filters _filters;

        static World()
        {
            Entities = new();
            _filters = new();
            Entities.Add(Events = new());
        }

        internal static Filters Filters 
            => _filters;
    }
}
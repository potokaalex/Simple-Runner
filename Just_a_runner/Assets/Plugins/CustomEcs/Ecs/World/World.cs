using System.Collections.Generic;

namespace Ecs
{
    public static class World
    {
        private static List<Entity> _entities = new();
        private static List<Filter> _filters = new();
        private static Entity _events = new();

        static World()
            => _entities.Add(_events);

        public static List<Entity> Entities
            => _entities;

        public static Entity Events
            => _events;

        internal static List<Filter> Filters
            => _filters;
    }
}
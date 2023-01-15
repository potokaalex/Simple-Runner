using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ecs
{
    public class EcsWorld
    {
        private HashSet<GameObject> _entities = new();
        //private HashSet<Event> _events = new();

        private HashSet<EcsComponentFilter<EcsComponent>> _filters = new();

        public bool TryAddFilter(EcsComponentFilter<EcsComponent> filter) => _filters.Add(filter);


        public bool TryAddEntity(GameObject entity) => _entities.Add(entity);

        // public bool TryAddEventEntity(EventEntity eventEntity) => _EVENTS_.Add(eventEntity);

        //public HashSet<EventEntity> Events => _EVENTS_;
    }
}

public class Event
{

}
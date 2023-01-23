using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs.Core;

namespace Ecs
{
    public class EventFilter<EventType> where EventType : IEvent
    {
        public IEnumerator<EventType> GetEnumerator() => EcsWorld.GetEventsByType<EventType>().GetEnumerator();
    }
}

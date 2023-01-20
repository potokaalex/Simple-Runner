using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Systems
{
    public class EventSystem : IFixedUpdateSystem
    {
        private HashSet<IEvent> _events = new();

        public void FixedUpdate(float deltaTime)
        {
            if (_events.Count < 1)
                return;

            _events.Clear();
        }

        public HashSet<IEvent> GetEvents() => _events;

        public bool TryAddEvent(IEvent eventEntity) => _events.Add(eventEntity);
    }
}

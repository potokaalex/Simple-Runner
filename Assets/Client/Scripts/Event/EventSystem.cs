using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ecs.Systems
{
    public class EventSystem : ILateUpdateSystem
    {
        private HashSet<IEvent> _events = new();

        public void LateUpdate(float deltaTime) //after a little analysis, I decided to clean up in LateUpdate
        {
            if (_events.Count < 1)
                return;

            _events.Clear();
        }

        public HashSet<IEvent> GetEvents() => _events;

        public bool TryAddEvent(IEvent eventEntity) => _events.Add(eventEntity);
    }
}

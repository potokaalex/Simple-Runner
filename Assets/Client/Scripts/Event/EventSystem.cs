using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Ecs.Systems
{
    public class EventSystem : IFixedUpdateSystem
    {
        private HashSet<IEvent> _events = new();

        public void FixedUpdate(float deltaTime) //after a little analysis, I decided to clean up in LateUpdate
        {
            if (_events.Count < 1)
                return;
            Debug.Log("Clear");
            _events.Clear();
        }

        public HashSet<IEvent> GetEvents() => _events;

        public bool TryAddEvent(IEvent eventEntity) => _events.Add(eventEntity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Events
{
    public class EventManager
    {

        private Dictionary<Type, List<Action<Event>>> _eventTable;

        public EventManager()
        {
            _eventTable = new Dictionary<Type, List<Action<Event>>>();
        }

        public void RegisterEvent<TYPE>(Action<Event> action) where TYPE : Event
        {
            Type event_type = typeof(TYPE);
            if (!_eventTable.ContainsKey(event_type))
            {
                _eventTable.Add(event_type, new List<Action<Event>>());
            }
            _eventTable[event_type].Add(action);
        }

        public void TriggerEvent(Event event_object)
        {
            Type event_type = event_object.GetType();
            if (_eventTable.ContainsKey(event_type))
            {
                foreach (Action<Event> action in _eventTable[event_type])
                {
                    action(event_object);
                }
            }
        }
    }
}

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

        public void RegisterEvent(Type type, Action<Event> action)
        {
            if (!_eventTable.ContainsKey(type))
            {
                _eventTable.Add(type, new List<Action<Event>>());
            }
            _eventTable[type].Add(action);
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

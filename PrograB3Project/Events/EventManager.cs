using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Events
{
    public class EventManager : Interfaces.IEventManager
    {

        private Dictionary<Type, List<Action<Interfaces.IEvent>>> _eventTable;

        public EventManager()
        {
            _eventTable = new Dictionary<Type, List<Action<Interfaces.IEvent>>>();
        }

        public void RegisterEvent<TYPE>(Action<Interfaces.IEvent> action) where TYPE : Interfaces.IEvent
        {
            Type event_type = typeof(TYPE);
            if (!_eventTable.ContainsKey(event_type))
            {
                _eventTable.Add(event_type, new List<Action<Interfaces.IEvent>>());
            }
            _eventTable[event_type].Add(action);
        }

        public void TriggerEvent(Interfaces.IEvent event_object)
        {
            Type event_type = event_object.GetType();
            if (_eventTable.ContainsKey(event_type))
            {
                foreach (Action<Interfaces.IEvent> action in _eventTable[event_type])
                {
                    action(event_object);
                }
            }
        }
    }
}

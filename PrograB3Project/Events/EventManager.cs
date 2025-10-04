using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Events
{
    public class EventManager : Interfaces.IEventManager
    {

        private Dictionary<Type, List<Action<Event>>> _eventTable;
        private Dictionary<Type, List<Action<Event>>> _eventToRegisterTable;
        private Dictionary<Type, List<Action<Event>>> _eventToDequeueTable;

        public EventManager()
        {
            _eventTable = new Dictionary<Type, List<Action<Event>>>();
            _eventToDequeueTable = new Dictionary<Type, List<Action<Event>>>();
            _eventToRegisterTable = new Dictionary<Type, List<Action<Event>>>();
        }

        public void RegisterEvent<TYPE>(Action<Event> action) where TYPE : Event
        {
            Type event_type = typeof(TYPE);

            if (!_eventToRegisterTable.ContainsKey(event_type))
            {
                _eventToRegisterTable.Add(event_type, new List<Action<Event>>());
            }
            _eventToRegisterTable[event_type].Add(action);
        }

        public void TriggerEvent(Event event_object)
        {
            DequeueEventToUnregister();
            DequeueEventToRegister();
            Type event_type = event_object.GetType();

            if (_eventTable.ContainsKey(event_type))
            {
                foreach (Action<Event> action in _eventTable[event_type])
                {
                    action(event_object);
                }
            }
            
        }

        public void UnregisterFromEvent<TYPE>(Action<Event> action) where TYPE : Event
        {
            Type event_type = typeof(TYPE);

            if (_eventTable.ContainsKey(event_type) && _eventTable[event_type].Contains(action))
            {
               if(!_eventToDequeueTable.ContainsKey(event_type))
                {
                    _eventToDequeueTable.Add(event_type, new List<Action<Event>>());
                    
                }
                _eventToDequeueTable[event_type].Add(action);
            }
            
        }

        public void DequeueEventToUnregister()
        {
            foreach(KeyValuePair<Type,List<Action<Event>>> entrie in _eventToDequeueTable)
            {
                foreach(Action<Event> action in entrie.Value)
                {
                    _eventTable[entrie.Key].Remove(action);
                }
            }
            _eventToDequeueTable.Clear();
        }
        public void DequeueEventToRegister()
        {
            foreach (KeyValuePair<Type, List<Action<Event>>> entrie in _eventToRegisterTable)
            {
                foreach (Action<Event> action in entrie.Value)
                {
                    if(!_eventTable.ContainsKey(entrie.Key))
                    {
                        _eventTable.Add(entrie.Key, new List<Action<Event>>());
                    }
                    if (!_eventTable[entrie.Key].Contains(action))
                    { 
                        _eventTable[entrie.Key].Add(action);
                    }
                }
            }
            _eventToRegisterTable.Clear();
        }
    }
}

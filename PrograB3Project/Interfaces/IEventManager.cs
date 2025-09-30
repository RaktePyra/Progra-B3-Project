using PrograB3Project.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Interfaces
{
    public interface IEventManager
    {
        public void RegisterEvent<TYPE>(Action<IEvent> action) where TYPE : IEvent;
        public void TriggerEvent(IEvent event_object);
    }
}

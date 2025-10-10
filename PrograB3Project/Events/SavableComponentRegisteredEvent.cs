using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Events
{
    public class SavableComponentRegisteredEvent : Event
    {
        private ISavableComponent _savableComponent;

        public SavableComponentRegisteredEvent(ISavableComponent component) 
        {
            _savableComponent = component;
        }

        public ISavableComponent GetComponent()
        {
            return _savableComponent;
        }
    }
}

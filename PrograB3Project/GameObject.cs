using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrograB3Project.Components;
using PrograB3Project.Events;
using PrograB3Project.Interfaces;
namespace PrograB3Project
{
    public class GameObject : IGameObject
    {
        private string _name;
        private List<Interfaces.IComponent> _componentsTable = new List<Interfaces.IComponent>();
        private Interfaces.IEventManager _eventManager;

        public GameObject(string name, Interfaces.IEventManager event_manager)
        {
            _name = name;
            _eventManager = event_manager;
        }

        
        public void Update(float delta_time)
        {
            foreach (Interfaces.IComponent component in _componentsTable)
            {
                component.Update(delta_time);
            }
        }

        public void AddComponent(Interfaces.IComponent component) 
        {
            if( !_componentsTable.Contains(component))
            {
              _componentsTable.Add(component);
                if (component is ISavableComponent)
                {
                    _eventManager.TriggerEvent(new SavableComponentRegisteredEvent((ISavableComponent)component));
                }
            }
            return;
        }

        public TYPE GetComponent<TYPE>() where TYPE : Interfaces.IComponent
        {
            TYPE component_to_return = default;

            foreach (Interfaces.IComponent component in _componentsTable)
            {
                if(component.GetType() == typeof(TYPE))
                {
                    component_to_return = (TYPE)component;
                    
                }
            }
            return component_to_return;
            
        }

        public string GetName()
        {
            return _name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrograB3Project.Components;
namespace PrograB3Project
{
    public class GameObject
    {
        private string _name;
        private List<Component> _componentsTable = new List<Component>();
        private GameEngine _engine;
        private Events.EventManager _eventManager;

        public GameObject(string name, GameEngine engine, Events.EventManager event_manager)
        {
            _name = name;
            _engine = engine;
            _eventManager = event_manager;
        }

        //To remove 
        public void Update(float delta_time)
        {
            foreach (Component component in _componentsTable)
            {
                component.Update(delta_time);
            }
        }

        public void AddComponent(Component component) 
        {
            if( !_componentsTable.Contains(component))
            {
              _componentsTable.Add(component);
            }
            return;
        }

        public TYPE GetComponent<TYPE>() where TYPE : Component
        {
            TYPE component_to_return = null;

            foreach (Component component in _componentsTable)
            {
                if(component.GetType() == typeof(TYPE))
                {
                    component_to_return =(TYPE)component;
                }
            }
            return component_to_return;
            
        }

        public string GetName()
        {
            return _name;
        }

        public GameEngine GetEngine()
        {
            return _engine;
        }

        public Events.EventManager GetEventManager()
        {
            return _eventManager;
        }
    }
}

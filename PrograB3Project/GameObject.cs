using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrograB3Project.Components;
using PrograB3Project.Interfaces;
namespace PrograB3Project
{
    public class GameObject : IGameObject
    {
        private string _name;
        private List<Interfaces.IComponent> _componentsTable = new List<Interfaces.IComponent>();
        private Interfaces.IGameEngine _engine;
        private Interfaces.IEventManager _eventManager;
        private RenderManager _renderManager;

        public GameObject(string name, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager,RenderManager render_manager)
        {
            _name = name;
            _engine = engine;
            _eventManager = event_manager;
            _renderManager = render_manager;
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

        public Interfaces.IGameEngine GetEngine()
        {
            return _engine;
        }

        public Interfaces.IEventManager GetEventManager()
        {
            return _eventManager;
        }

        public RenderManager GetRenderManager()
        {
           return _renderManager;
        }
    }
}

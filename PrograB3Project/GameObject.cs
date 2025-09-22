using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrograB3Project.Components;
namespace PrograB3Project
{
    internal class GameObject
    {
        List<Component> _componentsTable = new List<Component>();
        public GameObject() { }

        public GameObject(Component component) 
        {
            _componentsTable.Add(component);
        }

        public void Update(float delta_time)
        { 

        }

        public void AddComponent<TYPE>(Component component) where TYPE : Component
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
            
    }
}

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
        private Context _gameContext;
        private GameEngine _engine;
        private bool _isRegisteredInEngine = false;

        public GameObject(string name,Context game_context) 
        { 
            _name = name;
            _gameContext = game_context;
            _engine = game_context.GetGameEngine();
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
            if(!_isRegisteredInEngine)
            {
                _gameContext.GetGameEngine().RegisterGameObject(this); // To avoid having to manually register GameObjects upon instanciation
                _isRegisteredInEngine = true;
            }

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

        public Context GetContext()
        {
            return _gameContext;
        }
    }
}

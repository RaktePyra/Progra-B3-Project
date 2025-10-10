using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class Component : IComponent
    {

        protected Interfaces.IGameEngine _gameEngine;
        protected Interfaces.IEventManager _eventManager;
        protected RenderManager _renderManager;
        protected IGameObject _ownerGameObject;
        
        public Component(IGameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager,RenderManager render_manager)
        {
            _ownerGameObject = owner;
            _ownerGameObject.AddComponent(this);
            _eventManager = event_manager;
            _gameEngine = engine;
            _renderManager = render_manager;

        }

        public void Update(float delta_time)
        {

        }

        public IGameObject GetOwnerGameObject()
        {
            return _ownerGameObject;
        }

        public virtual void ProcessInput(ConsoleKeyInfo key)
        {

        }
    }
}

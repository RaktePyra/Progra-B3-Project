using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class KeyLocationComponent : Component
    {
        protected LocationComponent _parentLocation;

        public KeyLocationComponent(Interfaces.IGameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager, LocationComponent parent_location, RenderManager render_manager) : base(owner, engine, event_manager, render_manager)
        {
            _parentLocation = parent_location;
            owner.AddComponent(this);
        }

        public virtual void Enter(Interfaces.IGameObject player)
        {
            player.GetComponent<InputComponent>().BeginInteraction(this);
        }

        public virtual void Exit(Interfaces.IGameObject player) 
        {
            _parentLocation.Enter(player);
        }
    }
}

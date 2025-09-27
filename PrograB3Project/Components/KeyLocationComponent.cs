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

        public KeyLocationComponent(GameObject owner,GameEngine engine, Events.EventManager event_manager, LocationComponent parent_location) : base(owner, engine, event_manager)
        {
            _parentLocation = parent_location;
            owner.AddComponent(this);
        }

        public virtual void Enter(GameObject player)
        {
            player.GetComponent<InputComponent>().BeginInteraction(this);
        }

        public virtual void Exit(GameObject player) 
        {
            _parentLocation.Enter(player);
        }
    }
}

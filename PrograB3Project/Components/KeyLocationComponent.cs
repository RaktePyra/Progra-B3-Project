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
        public KeyLocationComponent(GameObject owner,Context game_context, LocationComponent parentLocation) : base(owner, game_context)
        {
            _parentLocation = parentLocation;
        }

        public virtual void Enter(GameObject player)
        {

        }
        public virtual void Exit(GameObject player) 
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    class InputComponent : Component
    {
        private Component _componentBeingInteractedWith;

        public InputComponent(GameObject owner, GameEngine engine) : base(owner)
        {
        }

        public void BeginInteraction(Component component_to_interact_with)
        {
            _componentBeingInteractedWith = component_to_interact_with;
        }

        public override void ProcessInput(ConsoleKeyInfo key)
        {
            _componentBeingInteractedWith.ProcessInput(key);
        }
    }
}

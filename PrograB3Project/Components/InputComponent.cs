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
        

        public InputComponent(GameObject owner,Context game_context) : base(owner, game_context)
        {
            game_context.GetEventManager().RegisterEvent<Events.InputEvent>(OnInput);
        }

        public void BeginInteraction(Component component_to_interact_with)
        {
            _componentBeingInteractedWith = component_to_interact_with;
        }

        public override void ProcessInput(ConsoleKeyInfo key)
        {
            _componentBeingInteractedWith.ProcessInput(key);
        }

        public void OnInput(Events.Event input_event)
        {
            Events.InputEvent real_event = (Events.InputEvent)input_event;
            ProcessInput(real_event.GetKeyInfo());
        }
    }
}

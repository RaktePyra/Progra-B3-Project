using PrograB3Project.Events;
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
        private MovementComponent _playerMovementComponent;
        private Interfaces.IEventManager _eventManager;

        public InputComponent(GameObject owner, Interfaces.IEventManager event_manager,MovementComponent player_movement_comp) : base(owner)
        {
            _eventManager = event_manager;
            event_manager.RegisterEvent<Events.InputEvent>(OnInput);
            _playerMovementComponent = player_movement_comp;
        }

        public void BeginInteraction(Component component_to_interact_with)
        {
            _componentBeingInteractedWith = component_to_interact_with;
        }

        public override void ProcessInput(ConsoleKeyInfo key)
        {
            if(_componentBeingInteractedWith is LocationComponent)
            {
                _playerMovementComponent.ProcessInput(key);
            }
            _componentBeingInteractedWith.ProcessInput(key);
        }

        public void OnInput(Events.Event input_event)
        {
            Events.InputEvent real_event = (Events.InputEvent)input_event;
            ProcessInput(real_event.GetKeyInfo());
        }
    }
}

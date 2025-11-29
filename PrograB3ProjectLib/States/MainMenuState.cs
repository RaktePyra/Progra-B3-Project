using PrograB3Project.Events;
using PrograB3Project.Interfaces;
using System;

namespace PrograB3Project.States
{
    internal class MainMenuState : IState
    {
        private StateMachine _stateMachine;
        private InGameState? _gameState;
        private IEventManager _eventManager;
        private GameEngine _engine;
        private GameObject _mainMenuObject;
        private CollisionManager _collisionManager;

        public MainMenuState(StateMachine state_machine,GameEngine engine, IEventManager event_manager, CollisionManager collision_manager)
        {
            _stateMachine = state_machine;
            _eventManager = event_manager;
            _engine = engine;
            _mainMenuObject = new GameObject("Main Menu", _eventManager);
            _collisionManager = collision_manager;
        }
        public void Enter()
        {
            _stateMachine.GetEventManager().RegisterEvent<InputEvent>(ProcessInput);
        }

        public void Exit()
        {
            _stateMachine.GetEventManager().UnregisterFromEvent<InputEvent>(ProcessInput);
        }

        public void ProcessInput(Event input_event)
        {
            InputEvent true_input_event = (InputEvent)input_event;
            ConsoleKeyInfo key_info = true_input_event.GetKeyInfo();
            switch (key_info.Key)
            {
                case ConsoleKey.NumPad1:
                    {

                        if (_gameState == null)
                        {
                            _gameState = new InGameState(_stateMachine,_collisionManager);
                        }
                        _stateMachine.ChangeState(_gameState);

                        break;
                    }
                    //Exiting is treated inside the Engine
            }
        }

        public void ProcessInput(ConsoleKeyInfo key_info)
        {
            throw new NotImplementedException();
        }

        public void Render()
        {

        }

        public void Update(float delta_time)
        {

        }
    }
}

using PrograB3Project.Events;
using PrograB3Project.Interfaces;

namespace PrograB3Project.States
{
    internal class MainMenuState : IState
    {
        private StateMachine _stateMachine;
        private InGameState _gameState;
        private RenderManager _renderManager;
        private IEventManager _eventManager;
        private GameEngine _engine;
        private TextualRenderComponent _textualRenderComponent;
        private GameObject _mainMenuObject;

        public MainMenuState(StateMachine state_machine,GameEngine engine,IEventManager event_manager, RenderManager render_manager)
        {
            _stateMachine = state_machine;
            _eventManager = event_manager;
            _engine = engine;
            _renderManager = render_manager;
            _mainMenuObject = new GameObject("Main Menu", _engine, _eventManager, _renderManager);
            _textualRenderComponent = new TextualRenderComponent(_mainMenuObject, _engine, _eventManager, "Main Menu.Press 1 to play.Press 2 to quit", _renderManager);

        }
        public void Enter()
        {
            _stateMachine.GetEventManager().RegisterEvent<InputEvent>(ProcessInput);
            _renderManager.RegisterRenderComponent(_textualRenderComponent);
        }

        public void Exit()
        {
            _stateMachine.GetEventManager().UnregisterFromEvent<InputEvent>(ProcessInput);
            _renderManager.RegisterRenderComponent(_textualRenderComponent);
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
                            _gameState = new InGameState(_stateMachine,_renderManager);
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

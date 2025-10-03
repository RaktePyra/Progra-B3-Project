using PrograB3Project.Events;

namespace PrograB3Project.States
{
    internal class MainMenuState : IState
    {
        private StateMachine _stateMachine;
        private InGameState _gameState;

        public MainMenuState(StateMachine state_machine)
        {
            _stateMachine = state_machine;
            
        }
        public void Enter()
        {
            _stateMachine.GetEventManager().RegisterEvent<InputEvent>(ProcessInput);
            Console.WriteLine("Main Menu");
            Console.WriteLine("Press 1 to play");
            Console.WriteLine("Press 2 to quit");
        }

        public void Exit()
        {
            _stateMachine.GetEventManager().UnregisterFromEvent<InputEvent>(ProcessInput);
            Console.WriteLine("Loading Game");
            Thread.Sleep(1000);
            Console.Clear();
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
                            _gameState = new InGameState(_stateMachine);
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

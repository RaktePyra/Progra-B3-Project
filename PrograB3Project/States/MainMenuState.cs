namespace PrograB3Project.States
{
    internal class MainMenuState : IState
    {
        private StateMachine _stateMachine;

        public MainMenuState(StateMachine state_machine)
        {
            _stateMachine = state_machine;
        }
        public void Enter()
        {
        }

        public void Exit()
        {

            Console.WriteLine("Loading Game");
            Thread.Sleep(1000);
        }

        public void ProcessInput(ConsoleKeyInfo key_info)
        {
            switch (key_info.Key)
            {
                case ConsoleKey.NumPad1:
                    {
                        _stateMachine.ChangeState(new InGameState(_stateMachine));
                        break;
                    }
                    //Exiting is treated inside the Engine
            }
        }

        public void Render()
        {

            Console.WriteLine("Main Menu");
            Console.WriteLine("Press 1 to play");
            Console.WriteLine("Press 2 to quit");
        }

        public void Update(float delta_time)
        {

        }
    }
}

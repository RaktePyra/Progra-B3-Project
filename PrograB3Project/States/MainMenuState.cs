using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Main Menu");
            Console.WriteLine("Press 1 to play");
            Console.WriteLine("Press 2 to quit");
           
        }

        public void Exit()
        {
            Console.Clear();
            Console.WriteLine("Loading Game");
            Thread.Sleep(1000);
        }

        public void Update(float delta_time)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.States
{
    internal class InGameState : IState
    {
        private int _updateCount = 0;
        private StateMachine _stateMachine;
        public InGameState(StateMachine state_machine) 
        {
            _stateMachine = state_machine;
        }

        public void Enter()
        {
           
        }

        public void Exit()
        {
           
        }

        public void ProcessInput(ConsoleKeyInfo key_info)
        {
            //Exiting is treated inside the Engine
        }

        public void Render()
        {
            Console.WriteLine("Been Playing for " + _updateCount + " frames");
            Console.WriteLine("Press Escape to quit");
        }

        public void Update(float delta_time)
        {
           _updateCount++;
            
        }
    }
}

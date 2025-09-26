using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.States
{
    internal class ShopMainState : IState
    {
        private StateMachine _stateMachine;
        public ShopMainState(StateMachine state_machine) 
        {
            _stateMachine = state_machine;
        }

        public void Enter()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the shop.");
            Console.WriteLine("What do you wanna do?");
            Console.WriteLine("1.Buy");
            Console.WriteLine("2.Sell");
            Console.WriteLine("3.Quit");
        }

        public void Exit()
        {
          
        }

        public void ProcessInput(ConsoleKeyInfo key_info)
        {
            int user_choice = (int)key_info.Key - (int)ConsoleKey.NumPad0;
            if (user_choice > 0 && user_choice < 3)
            {
                switch(user_choice)
                {
                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                }
            }
        }

        public void Render()
        {
          
        }

        public void Update(float delta_time)
        {
          
        }
    }
}

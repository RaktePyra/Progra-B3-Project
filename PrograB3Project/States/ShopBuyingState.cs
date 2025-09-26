using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.States
{
    internal class ShopBuyingState : IState
    {
        private StateMachine _shopStateMachine;
        private ShopMainState _shopMainState;
        private Context _gameContext;
        public ShopBuyingState(StateMachine state_machine, Context game_context, ShopMainState shop_main_state) 
        {
            _shopStateMachine = state_machine;
            _gameContext = game_context;
            _shopMainState = shop_main_state;
        }
        public void Enter()
        {
            Console.Clear();


        }

        public void Exit()
        {
         _shopStateMachine.ChangeState(_shopMainState);
        }

        public void ProcessInput(ConsoleKeyInfo key_info)
        {
            int user_choice = (int)key_info.Key - (int)ConsoleKey.NumPad1;
            switch (user_choice)
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

        public void Render()
        {
          
        }

        public void Update(float delta_time)
        {
           
        }
    }
}

using PrograB3Project.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.States
{
    public class ShopMainState : IState
    {
        private StateMachine _stateMachine;
        private ShopBuyingState _shopBuyingState;
        private Interfaces.IGameObject _player;
        private Interfaces.IGameObject _shopGameObject;
        public ShopMainState(StateMachine state_machine, Interfaces.IGameObject player, Interfaces.IGameObject shop) 
        {
            _stateMachine = state_machine;
            _player = player;
            _shopGameObject = shop;
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

            if (user_choice > 0 && user_choice <= 3)
            {
                switch(user_choice)
                {
                    case 1:
                        {
                            _stateMachine.ChangeState(new ShopBuyingState(_stateMachine, _shopGameObject.GetEngine(),_shopGameObject.GetEventManager(), this, _shopGameObject,_player));
                            break;
                        }
                    case 2:
                        {
                            _stateMachine.ChangeState(new ShopSellingState(_stateMachine, _shopGameObject.GetEngine(), _shopGameObject.GetEventManager(), this, _shopGameObject, _player));
                            break;
                        }
                    case 3:
                        {
                            _shopGameObject.GetComponent<ShopComponent>().Exit(_player);
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

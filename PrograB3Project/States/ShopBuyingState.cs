using PrograB3Project.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.States
{
    public class ShopBuyingState : IState
    {
        private StateMachine _shopStateMachine;
        private ShopMainState _shopMainState;
        private Context _gameContext;
        private GameObject _player;
        private GameObject _shop;
        private TradingComponent _shopTradingComponent;

        public ShopBuyingState(StateMachine state_machine, Context game_context, ShopMainState shop_main_state, GameObject shop, GameObject player) 
        {
            _shopStateMachine = state_machine;
            _gameContext = game_context;
            _shopMainState = shop_main_state;
            _gameContext = shop.GetContext();
            _shopTradingComponent = shop.GetComponent<TradingComponent>();
            _player = player;
            _shop = shop;
        }

        public void Enter()
        {
            Console.Clear();
            Console.WriteLine("Press 0 to quit");
            Console.WriteLine();
            Console.WriteLine("Your Gold : " + _player.GetComponent<InventoryComponent>().GetMoney());
            Console.WriteLine();
            Console.WriteLine("The shop's Inventory");
            Console.WriteLine();
            _shop.GetComponent<InventoryComponent>().Display();

        }

        public void Exit()
        {
        
        }

        public void ProcessInput(ConsoleKeyInfo key_info)
        {
            int user_choice = (int)key_info.Key - (int)ConsoleKey.NumPad1;

            if (user_choice >= 0 && user_choice < _shop.GetComponent<InventoryComponent>().GetNumberOfItems())
            {
                _shopTradingComponent.BuyItemFromVendor(user_choice, _player.GetComponent<InventoryComponent>());
                Thread.Sleep(1000);
                Enter();
            }

            else if (user_choice == -1)
            {
                _shopStateMachine.ChangeState(_shopMainState);
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

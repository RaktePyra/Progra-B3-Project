using PrograB3Project.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.States
{
    public class ShopSellingState : IState
    {
        private StateMachine _shopStateMachine;
        private ShopMainState _shopMainState;
        private TradingComponent _shopTradingComponent;
        private GameEngine _engine;
        private Events.EventManager _eventManager;
        private GameObject _player;
        private GameObject _shop;

        public ShopSellingState(StateMachine state_machine,GameEngine engine, Events.EventManager event_manager, ShopMainState shop_main_state, GameObject shop, GameObject player)
        {
            _shopStateMachine = state_machine;
            _shopMainState = shop_main_state;
            _shopTradingComponent = shop.GetComponent<TradingComponent>();
            _player = player;
            _shop = shop;
            _eventManager = event_manager;
            _engine = engine;
        }

        public void Enter()
        {
            Console.Clear();
            Console.WriteLine("Press 0 to quit");
            Console.WriteLine();
            Console.WriteLine("Your Gold : " + _player.GetComponent<InventoryComponent>().GetMoney());
            Console.WriteLine();
            Console.WriteLine("Your Inventory");
            Console.WriteLine();
            _player.GetComponent<InventoryComponent>().Display();
            Console.WriteLine();
            Console.WriteLine("The Shop money : " + _shop.GetComponent<InventoryComponent>().GetMoney());


        }

        public void Exit()
        {
         
        }

        public void ProcessInput(ConsoleKeyInfo key_info)
        {
            int user_choice = (int) key_info.Key - (int)ConsoleKey.NumPad1;

            if (user_choice >= 0 && user_choice < _player.GetComponent<InventoryComponent>().GetNumberOfItems())
            {
                _shopTradingComponent.SellItemToVendor(user_choice,_player.GetComponent<InventoryComponent>());
                Thread.Sleep(1000);
                Enter();
            }

            else if(user_choice == -1)
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

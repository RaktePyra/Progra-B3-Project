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
        private Interfaces.IGameEngine _engine;
        private Interfaces.IEventManager _eventManager;
        private Interfaces.IGameObject _player;
        private Interfaces.IGameObject _shop;

        public ShopSellingState(StateMachine state_machine, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager, ShopMainState shop_main_state, Interfaces.IGameObject shop, Interfaces.IGameObject player)
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
            InventoryComponent player_inventory = _player.GetComponent<InventoryComponent>();
            Console.Clear();
            Console.WriteLine("Press 0 to quit");
            Console.WriteLine();
            Console.WriteLine("Your Gold : " + player_inventory.GetMoney());
            Console.WriteLine();
            Console.WriteLine("Your Inventory");
            Console.WriteLine();
            int number_of_items_inside_shop = player_inventory.GetNumberOfItems();
            for (int item_index = 0; item_index < number_of_items_inside_shop; item_index++)
            {
                Console.WriteLine(item_index + 1 + "." + player_inventory.GetItem(item_index).GetName() + " |Quantity : " + player_inventory.GetItem(item_index).GetQuantity() + " |Price : " + player_inventory.GetItem(item_index).GetPrice() * (_player.GetComponent<CharacterComponent>().GetBargainingStat()));
            }
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
                _shopTradingComponent.SellItemToVendor(user_choice,_player.GetComponent<InventoryComponent>(),_player.GetComponent<CharacterComponent>());
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

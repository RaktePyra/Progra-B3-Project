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
        private GameEngine _engine;
        private Events.EventManager _eventManager;
        private GameObject _player;
        private GameObject _shop;
        private TradingComponent _shopTradingComponent;

        public ShopBuyingState(StateMachine state_machine, GameEngine engine, Events.EventManager event_manager, ShopMainState shop_main_state, GameObject shop, GameObject player) 
        {
            _shopStateMachine = state_machine;
            
            _shopMainState = shop_main_state;
            _engine = engine;
            _eventManager = event_manager;
            _shopTradingComponent = shop.GetComponent<TradingComponent>();
            _player = player;
            _shop = shop;
        }

        public void Enter()
        {
            CharacterComponent player_character = _player.GetComponent<CharacterComponent>();
            InventoryComponent shop_inventory = _shop.GetComponent<InventoryComponent>();
            Console.Clear();
            Console.WriteLine("Press 0 to quit");
            Console.WriteLine();
            Console.WriteLine("Your Gold : " + _player.GetComponent<InventoryComponent>().GetMoney());
            Console.WriteLine();
            Console.WriteLine("The shop's Inventory");
            Console.WriteLine();
            int number_of_items_inside_shop = shop_inventory.GetNumberOfItems();
            for (int item_index = 0; item_index < number_of_items_inside_shop; item_index++)
            {
                Console.WriteLine(item_index + 1 + "." + shop_inventory.GetItem(item_index).GetName() + " |Quantity : " + shop_inventory.GetItem(item_index).GetQuantity() + " |Price : " + shop_inventory.GetItem(item_index).GetPrice()/(player_character.GetBargainingStat()));
            }
            

        }

        public void Exit()
        {
        
        }

        public void ProcessInput(ConsoleKeyInfo key_info)
        {
            int user_choice = (int)key_info.Key - (int)ConsoleKey.NumPad1;

            if (user_choice >= 0 && user_choice < _shop.GetComponent<InventoryComponent>().GetNumberOfItems())
            {
                _shopTradingComponent.BuyItemFromVendor(user_choice, _player.GetComponent<InventoryComponent>(), _player.GetComponent<CharacterComponent>());
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

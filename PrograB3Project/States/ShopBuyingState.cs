using PrograB3Project.Components;
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
        private GameObject _player;
        private GameObject _shop;
        public ShopBuyingState(StateMachine state_machine, Context game_context, ShopMainState shop_main_state, GameObject shop, GameObject player) 
        {
            _shopStateMachine = state_machine;
            _gameContext = game_context;
            _shopMainState = shop_main_state;
            _gameContext = shop.GetContext();
            _player = player;
            _shop = shop;
        }
        public void Enter()
        {
            Console.Clear();
            Console.WriteLine("Your Inventory");
            Console.WriteLine();
            _player.GetComponent<InventoryComponent>().Display();
            Console.WriteLine("The shop's Inventory");
            Console.WriteLine();
            _shop.GetComponent<InventoryComponent>().Display();

        }

        public void Exit()
        {
         _shopStateMachine.ChangeState(_shopMainState);
        }

        public void ProcessInput(ConsoleKeyInfo key_info)
        {
            int user_choice = (int)key_info.Key - (int)ConsoleKey.NumPad1;

        }

        public void Render()
        {
          
        }

        public void Update(float delta_time)
        {
           
        }
    }
}

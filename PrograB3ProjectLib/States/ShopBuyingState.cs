using PrograB3Project.Components;
using System;
using System.Threading;

namespace PrograB3Project.States
{
    public class ShopBuyingState : IState
    {
        private StateMachine _shopStateMachine;
        private ShopMainState _shopMainState;
        private Interfaces.IGameObject _player;
        private Interfaces.IGameObject _shop;
        private TradingComponent _shopTradingComponent;

        public ShopBuyingState(StateMachine state_machine, ShopMainState shop_main_state, Interfaces.IGameObject shop, Interfaces.IGameObject player)
        {
            _shopStateMachine = state_machine;
            _shopMainState = shop_main_state;
            _shopTradingComponent = shop.GetComponent<TradingComponent>();
            _player = player;
            _shop = shop;
        }

        public void Enter()
        {
            InventoryComponent shop_inventory = _shop.GetComponent<InventoryComponent>();
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

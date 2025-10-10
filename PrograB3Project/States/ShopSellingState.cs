using PrograB3Project.Components;
using PrograB3Project.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.States
{
    public class ShopSellingState : IState
    {
        private Timer _timer;
        private StateMachine _shopStateMachine;
        private ShopMainState _shopMainState;
        private TradingComponent _shopTradingComponent;
        private ShopSellingStateRenderComponent _shopSellingStateRenderComponent;
        private Interfaces.IGameObject _player;
        private Interfaces.IGameObject _shop;
        private RenderManager _renderManager;

        public ShopSellingState(StateMachine state_machine, ShopMainState shop_main_state, Interfaces.IGameObject shop, Interfaces.IGameObject player,ShopSellingStateRenderComponent shop_selling_render_comp, RenderManager render_manager)
        {
            _shopStateMachine = state_machine;
            _shopMainState = shop_main_state;
            _shopTradingComponent = shop.GetComponent<TradingComponent>();
            _player = player;
            _shop = shop;
            _renderManager = render_manager;
            _shopSellingStateRenderComponent = shop_selling_render_comp;
        }

        public void Enter()
        {
            InventoryComponent player_inventory = _player.GetComponent<InventoryComponent>();
            _renderManager.RegisterRenderComponent(_shopSellingStateRenderComponent);
            _shopSellingStateRenderComponent.OnPlayerEnterShopSellingState(_player);
        }

        public void Exit()
        {
            _renderManager.UnregisterRenderComponent(_shopSellingStateRenderComponent);
        }

        public void ProcessInput(ConsoleKeyInfo key_info)
        {
            int user_choice = (int) key_info.Key - (int)ConsoleKey.NumPad1;

            if (user_choice >= 0 && user_choice < _player.GetComponent<InventoryComponent>().GetNumberOfItems())
            {
                _shopTradingComponent.SellItemToVendor(user_choice,_player.GetComponent<InventoryComponent>(),_player.GetComponent<CharacterComponent>());
                _timer = new Timer(Enter, 1);
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
           _timer.Update(delta_time);
        }
    }
}

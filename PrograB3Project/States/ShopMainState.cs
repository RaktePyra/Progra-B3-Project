using PrograB3Project.Components;
using PrograB3Project.Components.Rendering;
using PrograB3Project.Events;
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
        private TextualRenderComponent _renderComponent;
        private RenderManager _renderManager;
        public ShopMainState(StateMachine state_machine, Interfaces.IGameObject player, Interfaces.IGameObject shop,RenderManager render_manager) 
        {
            _renderManager = render_manager;    
            _stateMachine = state_machine;
            _player = player;
            _shopGameObject = shop;
            _renderComponent = new TextualRenderComponent(shop,"Welcome to the shop.What do you wanna do?.1 Buy.2 Sell.3 Quit" ,render_manager);
        }

        public void Enter()
        {
          _renderManager.RegisterRenderComponent(_renderComponent);
        }

        public void Exit()
        {
            _renderManager.UnregisterRenderComponent(_renderComponent);
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
                            _stateMachine.ChangeState(new ShopBuyingState(_stateMachine, this, _shopGameObject,_player,_shopGameObject.GetComponent<ShopBuyingStateRenderComponent>(),_renderManager));
                            break;
                        }
                    case 2:
                        {
                            _stateMachine.ChangeState(new ShopSellingState(_stateMachine, this, _shopGameObject, _player, _shopGameObject.GetComponent<ShopSellingStateRenderComponent>(), _renderManager));
                            break;
                        }
                    case 3:
                        {
                            Exit();
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

using PrograB3Project.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    internal class ShopComponent : KeyLocationComponent
    {
        
        private TradingComponent _shopTradingComponent;
        private InventoryComponent _shopInventoryComponent;
        private StateMachine _shopStateMachine;

        public ShopComponent(Interfaces.IGameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager,LocationComponent owner_location,TradingComponent trading_comp, InventoryComponent shop_inventory_comp, RenderManager render_manager) : base(owner,engine, event_manager,owner_location,render_manager)
        {
            
            _shopTradingComponent = trading_comp;
            _shopInventoryComponent = shop_inventory_comp;
            _shopStateMachine = new StateMachine(engine,event_manager);
        }

        public override void Enter(Interfaces.IGameObject player)
        {
            base.Enter(player);
            switch (_shopStateMachine.IsInitialized())
            {
                case true:
                    {
                        //Problem : Player reference will not be refreshed so there cannot be two players for the moment
                        _shopStateMachine.Refresh();
                        break;
                    }
                case false:
                    {
                        _shopStateMachine.SetInitialState(new ShopMainState(_shopStateMachine, player,_shopInventoryComponent.GetOwnerGameObject()));
                        break;
                    }
            }
        }

        public override void ProcessInput(ConsoleKeyInfo key)
        {
            _shopStateMachine.ProcessInput(key);
        }

       
    }
}

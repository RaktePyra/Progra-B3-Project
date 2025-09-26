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

        public ShopComponent(GameObject owner,TradingComponent trading_comp, InventoryComponent shop_inventory_comp) : base(owner)
        {
            _shopTradingComponent = trading_comp;
            _shopInventoryComponent = shop_inventory_comp;
        }

        public override void Enter(GameObject player)
        {
            player.GetComponent<InputComponent>().BeginInteraction(this);
        }

        public override void ProcessInput(ConsoleKeyInfo key)
        {
            
        }
    }
}

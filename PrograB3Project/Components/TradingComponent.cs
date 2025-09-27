using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    internal class TradingComponent : Component
    {
        private InventoryComponent _vendorInventory;
        public TradingComponent(GameObject owner,GameEngine engine, Events.EventManager event_manager) : base(owner, engine, event_manager)
        {
            _vendorInventory = owner.GetComponent<InventoryComponent>();
        }

        public void BuyItemFromVendor(int item_index,InventoryComponent buyer_inventory, CharacterComponent buyer_character_stats)
        {
            if (_vendorInventory.GetItem(item_index) != null && buyer_inventory.GetMoney() >= _vendorInventory.GetItem(item_index).GetPrice() / buyer_character_stats.GetBargainingStat())
            {
                Console.WriteLine("You bought " + _vendorInventory.GetItem(item_index).GetName() + " for " + _vendorInventory.GetItem(item_index).GetPrice() / buyer_character_stats.GetBargainingStat() + " gold");
                int item_price = _vendorInventory.GetItem(item_index).GetPrice() / buyer_character_stats.GetBargainingStat();
                _vendorInventory.AddMoney(item_price);
                buyer_inventory.RemoveMoney(item_price);
                buyer_inventory.AddItem(_vendorInventory.GetItem(item_index));
                _vendorInventory.RemoveItem(_vendorInventory.GetItem(item_index));
            }
        }

        public void SellItemToVendor(int item_index,InventoryComponent seller_inventory, CharacterComponent buyer_character_stats)
        {
            if (seller_inventory.GetItem(item_index) != null && _vendorInventory.GetMoney() >= seller_inventory.GetItem(item_index).GetPrice())
            {
                Console.WriteLine("You sold " + seller_inventory.GetItem(item_index).GetName() + " for " + seller_inventory.GetItem(item_index).GetPrice() + " gold");
                int item_price = seller_inventory.GetItem(item_index).GetPrice();
                _vendorInventory.RemoveMoney(item_price);
                seller_inventory.AddMoney(item_price);
                _vendorInventory.AddItem(seller_inventory.GetItem(item_index));
                seller_inventory.RemoveItem(seller_inventory.GetItem(item_index));
                
            }
        }
        
    }
}

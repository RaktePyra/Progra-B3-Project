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
        public TradingComponent(GameObject owner,Context game_context) : base(owner, game_context)
        {
            _vendorInventory = owner.GetComponent<InventoryComponent>();
        }

        public void BuyItemFromVendor(int item_index,InventoryComponent buyer_inventory)
        {
            if (_vendorInventory.GetItem(item_index) != null && buyer_inventory.GetMoney() >= _vendorInventory.GetItem(item_index).GetPrice())
            {
                int item_price = _vendorInventory.GetItem(item_index).GetPrice();
                _vendorInventory.AddMoney(item_price);
                buyer_inventory.RemoveMoney(item_price);
                buyer_inventory.AddItem(_vendorInventory.GetItem(item_index));
                _vendorInventory.RemoveItem(_vendorInventory.GetItem(item_index));
            }
        }

        public void SellItemToVendor(int item_index,InventoryComponent seller_inventory)
        {
            if (seller_inventory.GetItem(item_index) != null && _vendorInventory.GetMoney() >= seller_inventory.GetItem(item_index).GetPrice())
            {
                int item_price = _vendorInventory.GetItem(item_index).GetPrice();
                _vendorInventory.RemoveMoney(item_price);
                seller_inventory.AddMoney(item_price);
                seller_inventory.RemoveItem(_vendorInventory.GetItem(item_index));
                _vendorInventory.AddItem(_vendorInventory.GetItem(item_index));
            }
        }
        
    }
}

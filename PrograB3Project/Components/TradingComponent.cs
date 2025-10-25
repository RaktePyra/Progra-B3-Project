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
        public TradingComponent(Interfaces.IGameObject owner) : base(owner)
        {
            _vendorInventory = owner.GetComponent<InventoryComponent>();
        }

        public void BuyItemFromVendor(int item_index,InventoryComponent buyer_inventory, CharacterComponent buyer_character_stats)
        {
            if (_vendorInventory.GetItem(item_index) != null && buyer_inventory.GetMoney() >= _vendorInventory.GetItem(item_index).GetPrice() / buyer_character_stats.GetBargainingStat())
            {
                int item_price = _vendorInventory.GetItem(item_index).GetPrice();
                int item_price_bargained = item_price + (int)(item_price * 0.7) - (buyer_character_stats.GetBargainingStat() / 100)*item_price;
                _vendorInventory.AddMoney(item_price_bargained);
                buyer_inventory.RemoveMoney(item_price_bargained);
                buyer_inventory.AddItem(_vendorInventory.GetItem(item_index));
                _vendorInventory.RemoveItem(_vendorInventory.GetItem(item_index));
            }
        }

        public void SellItemToVendor(int item_index,InventoryComponent seller_inventory, CharacterComponent buyer_character_stats)
        {
            if (seller_inventory.GetItem(item_index) != null && _vendorInventory.GetMoney() >= seller_inventory.GetItem(item_index).GetPrice() * buyer_character_stats.GetBargainingStat())
            {
                int item_price = seller_inventory.GetItem(item_index).GetPrice();
                int item_price_bargained = item_price * (buyer_character_stats.GetBargainingStat() / 70);
                Console.WriteLine("You sold " + seller_inventory.GetItem(item_index).GetName() + " for " + item_price_bargained + " gold");
                _vendorInventory.RemoveMoney(item_price_bargained);
                seller_inventory.AddMoney(item_price_bargained);
                _vendorInventory.AddItem(seller_inventory.GetItem(item_index));
                seller_inventory.RemoveItem(seller_inventory.GetItem(item_index));
                
            }
        } 
    }
}

using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components.Rendering
{
    public class ShopBuyingStateRenderComponent : TextualRenderComponent
    {
        InventoryComponent _shopInventoryComponent;
        InventoryComponent _playerInventory;
        CharacterComponent _playerCharacterComponent;
        public ShopBuyingStateRenderComponent(IGameObject owner, IGameEngine engine, IEventManager event_manager, RenderManager render_manager,InventoryComponent shop_inventory_component) : base(owner, engine, event_manager, "Unused Text", render_manager)
        {
            _shopInventoryComponent = shop_inventory_component;
        }

        public void OnPlayerEnterShopBuyingState(IGameObject player)
        {
            _playerInventory = player.GetComponent<InventoryComponent>();
            _playerCharacterComponent = player.GetComponent<CharacterComponent>();
        }
        public override void Render()
        {
            Console.WriteLine("Press 0 to quit");
            Console.WriteLine();
            Console.WriteLine("Your Gold : " + _playerInventory.GetMoney());
            Console.WriteLine();
            Console.WriteLine("The shop's Inventory");
            Console.WriteLine();
            int number_of_items_inside_shop = _shopInventoryComponent.GetNumberOfItems();
            for (int item_index = 0; item_index < number_of_items_inside_shop; item_index++)
            {
                Console.WriteLine(item_index + 1 + "." + _shopInventoryComponent.GetItem(item_index).GetName() + " |Quantity : " + _shopInventoryComponent.GetItem(item_index).GetQuantity() + " |Price : " + _shopInventoryComponent.GetItem(item_index).GetPrice() / (_playerCharacterComponent.GetBargainingStat()));
            }
        }

    }
}

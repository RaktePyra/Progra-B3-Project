using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    internal class InventoryComponent : Component
    {
        private List<ItemComponent> _itemTable = new List<ItemComponent>();

        public InventoryComponent(GameObject owner,Context game_context) : base(owner, game_context) 
        {

        }

        public void AddItem(ItemComponent item)
        {
            if(!_itemTable.Contains(item))
            {
                _itemTable.Add(item);
            }
        }

        public void RemoveItem(ItemComponent item)
        {
            if (_itemTable.Contains(item))
            {
                _itemTable.Remove(item);
            }
        }

        public ItemComponent GetItem(int index)
        {
            return _itemTable[index];
        }
    }
}

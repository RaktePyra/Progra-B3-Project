using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class InventoryComponent : Component
    {
        private List<IItem> _itemTable = new List<IItem>();
        private int _money = 100;

        public InventoryComponent(Interfaces.IGameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager) : base(owner, engine, event_manager) 
        {
           
        }

        public void AddItem(IItem item)
        {
            if(!_itemTable.Contains(item))
            {
                _itemTable.Add(item);
            }
        }

        public void RemoveItem(IItem item)
        {
            if (_itemTable.Contains(item))
            {
                _itemTable.Remove(item);
            }
        }

        public IItem GetItem(int index)
        {
            IItem item_to_return = null;

            if(index < _itemTable.Count && index >= 0)
            {
                item_to_return = _itemTable[index];
            }
            return item_to_return;
        }

        public void Display()
        {
            Console.WriteLine("---------------------------------");

            for (int item_index = 0; item_index < _itemTable.Count; item_index++)
            {
                Console.WriteLine(item_index + 1 + "." + _itemTable[item_index].GetName() + " |Quantity : " + _itemTable[item_index].GetQuantity() + " |Price : " + _itemTable[item_index].GetPrice());
            }
        }

        public int GetMoney()
        {
            return _money;
        }

        public void AddMoney(int money)
        {
            _money += money;
        }

        public void RemoveMoney(int money)
        {
            _money -= money;
        }

        public int GetNumberOfItems()
        {
            return (_itemTable.Count);
        }
    }
}

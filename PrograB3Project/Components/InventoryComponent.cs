using PrograB3Project.Interfaces;

namespace PrograB3Project.Components
{
    public class InventoryComponent : Component, ISavableComponent
    {
        private List<IItem> _itemTable = new List<IItem>();
        private int _money = 100;
        private string _id;
        private IEventManager _eventManager;

        public InventoryComponent(Interfaces.IGameObject owner, Interfaces.IEventManager event_manager) : base(owner)
        {
            _id = owner.GetName() + "_inventory";
        }

        public void AddItem(IItem item)
        {
            if (!_itemTable.Contains(item))
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

            if (index < _itemTable.Count && index >= 0)
            {
                item_to_return = _itemTable[index];
            }
            return item_to_return;
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

        public string Save()
        {
            string serialized_inventory = _id + "";
            foreach (ItemComponent item in _itemTable)
            {
                serialized_inventory += "/" + item.Serialize();
            }
            return serialized_inventory;
        }

        public void RestoreDataFromFile(string data)
        {
            _itemTable.Clear();
            string[] inventory_data = data.Split("/");

            foreach (string item_data in inventory_data)
            {
                try
                {
                    string[] item_values = item_data.Split(";");
                    GameObject item = new GameObject(item_values[0], _eventManager);
                    ItemComponent item_comp = new ItemComponent(item, item_values[0], int.Parse(item_values[1]), int.Parse(item_values[2]));
                    _itemTable.Add(item_comp);
                }
                catch
                {
                    continue;
                }
            }
        }

        public string GetID()
        {
            return _id;
        }
    }
}

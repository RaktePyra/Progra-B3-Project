using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class ItemComponent : Component,Interfaces.IItem
    {
        private string _name;
        private int _quantity;
        private int _price;

        public ItemComponent(Interfaces.IGameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager,string name, int quantity, int price, RenderManager render_manager) : base(owner,engine,event_manager,render_manager)
        {
            _name = name;
            _quantity = quantity;
            _price = price;
        }

        public void AddQuantity(int quantity_to_add)
        {
            _quantity += quantity_to_add;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        public int GetPrice()
        {
            return _price;
        }

        public string GetName()
        {
            return _name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    //Can i use a non predetermined type if i create it myself?
    //Ressource : https://stackoverflow.com/questions/48926915/whats-the-point-of-having-methods-in-structs
    //After research it seems a struct is a value type instead of a reference type like the class
    //For Inventory purposes, ItemStruct should not be immutable but it seems this is a recommendation 
    //internal struct ItemStruct
    //{
    //    public readonly string _name;
    //    public readonly int _quantity;
    //    public readonly int _maxStackAmount;
    //}
    public class ItemComponent : Component,Interfaces.IItem
    {
        private string _name;
        private int _quantity;
        private int _price;

        public ItemComponent(GameObject owner, GameEngine engine, Events.EventManager event_manager,string name, int quantity, int price) : base(owner,engine,event_manager)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project
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
    public class Item
    {
        private string _name;
        private int _quantity;
        private int _maxStackAmount;

        public Item(string name, int quantity, int maxStackAmount)
        {
            _name = name;
            _quantity = quantity;
            _maxStackAmount = maxStackAmount;
        }
        //Adds the quantity to the item and returns a valid item if quantity has exceeded max Stack Amount. Otherwise, returns a default item
        public Item AddQuantity(int quantity_to_add)
        {
            Item item_to_return = new Item("",0,0);
            _quantity += quantity_to_add;

            if (_quantity > _maxStackAmount)
            {
                item_to_return= new Item(_name,_quantity-_maxStackAmount, _maxStackAmount);
            }
            return item_to_return;
        }
    }
}

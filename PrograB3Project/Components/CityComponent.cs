using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    internal class CityComponent : LocationComponent
    {
        private List<KeyLocationComponent> _locationTable = new List<KeyLocationComponent>();
        public CityComponent(GameObject owner, Context game_context) : base(owner, game_context)
        {
            GameObject shop = new GameObject("Shop",game_context);
            InventoryComponent shop_inventory = new InventoryComponent(shop, game_context);
            GameObject sword = new GameObject("Sword", game_context);
            ItemComponent sword_comp = new ItemComponent(sword, game_context,"sword",1,10);
            shop_inventory.AddItem(sword_comp);
            TradingComponent shop_trading_comp = new TradingComponent(shop, game_context);
            ShopComponent shop_component = new(shop, game_context,this,shop_trading_comp,shop_inventory);
            AddLocation(shop_component);
           
        }

        public override void Enter(GameObject player)
        {
            base.Enter(player);
           
            Console.Clear();
            Console.WriteLine("Welcome to " + GetOwnerGameObject().GetName() + " City.");
            Console.WriteLine("Where do you wanna go?");

            for (int location_index = 0; location_index < _locationTable.Count; location_index++)
            {
                Console.WriteLine(location_index + 1 + ". " + _locationTable[location_index].GetOwnerGameObject().GetName());
            }
            Console.WriteLine(_locationTable.Count + 1 + ". Go back to " + _parentLocation.GetOwnerGameObject().GetName());
        }

        public override void ProcessInput(ConsoleKeyInfo key)
        {
           int user_choice = (int) key.Key - (int)ConsoleKey.NumPad1;

            if (user_choice >= 0 && user_choice < _locationTable.Count)
            {
                _locationTable[user_choice].Enter(GetPlayer());
            }
            else if (user_choice == _locationTable.Count)
            {
                Console.Clear();
                _parentLocation.Enter(GetPlayer());
            }

        }

        public void AddLocation(KeyLocationComponent location)
        {
            if(!_locationTable.Contains(location))
            {
                _locationTable.Add(location);
            }
        }
    }
}

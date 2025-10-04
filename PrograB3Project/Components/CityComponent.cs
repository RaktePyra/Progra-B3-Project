using PrograB3Project.Events;
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

        public CityComponent(Interfaces.IGameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager,RenderManager render_manager, int level_size_x,int level_size_y) : base(owner, engine, event_manager, render_manager, level_size_x, level_size_y)
        {
            Interfaces.IGameObject shop = new GameObject("Shop", engine, event_manager,render_manager);
            InventoryComponent shop_inventory = new InventoryComponent(shop, engine, event_manager, render_manager);
            shop_inventory.AddMoney(9900);
            Interfaces.IGameObject sword = new GameObject("Sword", engine, event_manager, render_manager);
            ItemComponent sword_comp = new ItemComponent(sword, engine, event_manager, "sword",1, 10, render_manager);
            shop_inventory.AddItem(sword_comp);
            TradingComponent shop_trading_comp = new TradingComponent(shop, engine, event_manager, render_manager);
            ShopComponent shop_component = new(shop, engine, event_manager, this,shop_trading_comp,shop_inventory, render_manager);
            AddLocation(shop_component);
            Interfaces.IGameObject job = new GameObject("Grind Shrine", engine, event_manager, render_manager);
            JobComponent grind_shrine = new JobComponent(job, engine, event_manager, this, render_manager);
            AddLocation(grind_shrine);
        }

        public override void Enter(Interfaces.IGameObject player)
        {
            base.Enter(player);
           
            Console.Clear();
            Console.WriteLine("Welcome to " + GetOwnerGameObject().GetName() + " City.");
            Console.WriteLine("Where do you wanna go?");

            for (int location_index = 0; location_index < _locationTable.Count; location_index++)
            {
                Console.WriteLine(location_index + 1 + "." + _locationTable[location_index].GetOwnerGameObject().GetName());
            }
            Console.WriteLine(_locationTable.Count + 1 + ".Go back to " + _parentLocation.GetOwnerGameObject().GetName());
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

using PrograB3Project.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Disables the code suggestion to remove the type after the "new" Operator
#pragma warning disable IDE0090
namespace PrograB3Project
{
    internal class Game
    {
        private GameEngine _engine;
        private Context _context;

        public Game(Context game_context)
        {   
            _context = game_context;
            _engine = game_context.GetGameEngine();
            
        }

        public void Run()
        {
            GameObject world = new GameObject("Tamriel", _context);
            WorldComponent world_component = new WorldComponent(world,_context);

            GameObject skyrim = new GameObject("Skyrim", _context);
            RegionComponent skyrim_region_comp = new RegionComponent(skyrim, _context);
            GameObject windhelm = new GameObject("WindHelm", _context);
            CityComponent city_windhelm_comp=new CityComponent(windhelm, _context);
            GameObject whiterun = new GameObject("Whiterun", _context);
            CityComponent city_whiterun_comp = new CityComponent(whiterun, _context);

            GameObject cyrodiil = new GameObject("Cyrodiil", _context);
            RegionComponent region_cyrodiil_comp = new RegionComponent(cyrodiil, _context);
            GameObject imperial_city = new GameObject("Imperial City", _context);
            CityComponent city_imperial_city_comp = new CityComponent(imperial_city, _context);
            GameObject kvatch = new GameObject("Kvatch", _context);
            CityComponent city_kvatch_comp = new CityComponent(kvatch, _context);

            skyrim_region_comp.AddLocation(city_windhelm_comp);
            skyrim_region_comp.AddLocation(city_whiterun_comp);

            region_cyrodiil_comp.AddLocation(city_imperial_city_comp);
            region_cyrodiil_comp.AddLocation (city_kvatch_comp);

            world_component.AddLocation(skyrim_region_comp);
            world_component.AddLocation (region_cyrodiil_comp);

            GameObject player = new GameObject("player", _context);
            player.AddComponent(new InputComponent(player, _context));
            InventoryComponent player_inventory = new InventoryComponent(player, _context);
            GameObject apple = new GameObject("Apple", _context);
            apple.AddComponent(new ItemComponent(apple, _context,"Apple",10,5));
            GameObject water = new GameObject("Water", _context);
            water.AddComponent(new ItemComponent(water, _context, "Water", 100, 1));
            player_inventory.AddItem(apple.GetComponent<ItemComponent>());
            player_inventory.AddItem(water.GetComponent<ItemComponent>());

            _engine.SetPlayer(player);
            world_component.Enter(player);
        }

        public void OnExit()
        {

        }   
    }
}

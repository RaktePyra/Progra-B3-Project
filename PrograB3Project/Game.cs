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
        private Events.EventManager _eventManager;

        public Game(GameEngine engine, Events.EventManager event_manager)
        {
            _engine = engine;
            _eventManager = event_manager;
        }

        public void Run()
        {
            GameObject world = new GameObject("Tamriel", _engine,_eventManager);
            _engine.RegisterGameObject(world);
            WorldComponent world_component = new WorldComponent(world, _engine, _eventManager);

            GameObject skyrim = new GameObject("Skyrim", _engine, _eventManager);
            _engine.RegisterGameObject(skyrim);
            RegionComponent skyrim_region_comp = new RegionComponent(skyrim, _engine, _eventManager);
            GameObject windhelm = new GameObject("WindHelm", _engine, _eventManager);
            _engine.RegisterGameObject(windhelm);
            CityComponent city_windhelm_comp=new CityComponent(windhelm, _engine, _eventManager);
            GameObject whiterun = new GameObject("Whiterun", _engine, _eventManager);
            _engine.RegisterGameObject(whiterun);
            CityComponent city_whiterun_comp = new CityComponent(whiterun, _engine, _eventManager);

            GameObject cyrodiil = new GameObject("Cyrodiil", _engine, _eventManager);
            _engine.RegisterGameObject(cyrodiil);
            RegionComponent region_cyrodiil_comp = new RegionComponent(cyrodiil, _engine, _eventManager);
            GameObject imperial_city = new GameObject("Imperial City", _engine, _eventManager);
            _engine.RegisterGameObject(imperial_city);
            CityComponent city_imperial_city_comp = new CityComponent(imperial_city, _engine, _eventManager);
            GameObject kvatch = new GameObject("Kvatch", _engine, _eventManager);
            _engine.RegisterGameObject(kvatch);
            CityComponent city_kvatch_comp = new CityComponent(kvatch, _engine, _eventManager);

            skyrim_region_comp.AddLocation(city_windhelm_comp);
            skyrim_region_comp.AddLocation(city_whiterun_comp);

            region_cyrodiil_comp.AddLocation(city_imperial_city_comp);
            region_cyrodiil_comp.AddLocation (city_kvatch_comp);

            world_component.AddLocation(skyrim_region_comp);
            world_component.AddLocation (region_cyrodiil_comp);

            GameObject player = new GameObject("player", _engine, _eventManager);
            _engine.RegisterGameObject(player);
            player.AddComponent(new InputComponent(player, _engine, _eventManager));
            player.AddComponent(new CharacterComponent(player, _engine, _eventManager));
            InventoryComponent player_inventory = new InventoryComponent(player, _engine, _eventManager);
            GameObject apple = new GameObject("Apple", _engine, _eventManager);
            apple.AddComponent(new ItemComponent(apple, _engine, _eventManager, "Apple",10,5));
            GameObject water = new GameObject("Water", _engine, _eventManager);
            water.AddComponent(new ItemComponent(water, _engine, _eventManager, "Water", 100, 1));
            player_inventory.AddItem(apple.GetComponent<ItemComponent>());
            player_inventory.AddItem(water.GetComponent<ItemComponent>());

            world_component.Enter(player);
        }

        public void OnExit()
        {

        }   
    }
}

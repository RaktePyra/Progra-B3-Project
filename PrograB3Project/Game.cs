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
        private Interfaces.IGameEngine _engine;
        private Interfaces.IEventManager _eventManager;
        private RenderManager _renderManager;

        public Game(Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager, RenderManager renderManager)
        {
            _engine = engine;
            _eventManager = event_manager;
            _renderManager = renderManager;
        }

        public void Run()
        {
            GameObject world = new GameObject("Tamriel", _engine,_eventManager,_renderManager);
            _engine.RegisterGameObject(world);
            WorldComponent world_component = new WorldComponent(world, _engine, _eventManager, _renderManager, 20, 20);

            GameObject skyrim = new GameObject("Skyrim", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(skyrim);
            RegionComponent skyrim_region_comp = new RegionComponent(skyrim, _engine, _eventManager,_renderManager,20,20);
            GameObject windhelm = new GameObject("WindHelm", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(windhelm);
            CityComponent city_windhelm_comp=new CityComponent(windhelm, _engine, _eventManager, _renderManager, 20, 20);
            GameObject whiterun = new GameObject("Whiterun", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(whiterun);
            CityComponent city_whiterun_comp = new CityComponent(whiterun, _engine, _eventManager, _renderManager, 20, 20);

            GameObject cyrodiil = new GameObject("Cyrodiil", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(cyrodiil);
            RegionComponent region_cyrodiil_comp = new RegionComponent(cyrodiil, _engine, _eventManager, _renderManager, 20, 20);
            GameObject imperial_city = new GameObject("Imperial City", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(imperial_city);
            CityComponent city_imperial_city_comp = new CityComponent(imperial_city, _engine, _eventManager, _renderManager, 20, 20);
            GameObject kvatch = new GameObject("Kvatch", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(kvatch);
            CityComponent city_kvatch_comp = new CityComponent(kvatch, _engine, _eventManager, _renderManager, 20, 20);

            skyrim_region_comp.AddLocation(city_windhelm_comp);
            skyrim_region_comp.AddLocation(city_whiterun_comp);

            region_cyrodiil_comp.AddLocation(city_imperial_city_comp);
            region_cyrodiil_comp.AddLocation (city_kvatch_comp);

            world_component.AddLocation(skyrim_region_comp);
            world_component.AddLocation (region_cyrodiil_comp);

            GameObject player = new GameObject("player", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(player);
            player.AddComponent(new TransformComponent(player,_engine,_eventManager,_renderManager));
            player.AddComponent(new InputComponent(player, _engine, _eventManager, _renderManager));
            player.AddComponent(new CharacterComponent(player, _engine, _eventManager, _renderManager));
            InventoryComponent player_inventory = new InventoryComponent(player, _engine, _eventManager, _renderManager);
            GameObject apple = new GameObject("Apple", _engine, _eventManager, _renderManager);
            apple.AddComponent(new ItemComponent(apple, _engine, _eventManager, "Apple",10,5, _renderManager));
            GameObject water = new GameObject("Water", _engine, _eventManager, _renderManager);
            water.AddComponent(new ItemComponent(water, _engine, _eventManager, "Water", 100, 1, _renderManager));
            player_inventory.AddItem(apple.GetComponent<ItemComponent>());
            player_inventory.AddItem(water.GetComponent<ItemComponent>());

            world_component.Enter(player);
        }
    }
}

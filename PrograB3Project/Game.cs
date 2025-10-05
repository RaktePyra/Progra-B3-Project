using PrograB3Project.Components;
using PrograB3Project.Components.Rendering;
//Disables the code suggestion to remove the type after the "new" Operator
#pragma warning disable IDE0090
namespace PrograB3Project
{
    internal class Game
    {
        private Interfaces.IGameEngine _engine;
        private Interfaces.IEventManager _eventManager;
        private RenderManager _renderManager;
        private CollisionManager _collisionManager;

        public Game(Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager, RenderManager render_manager, CollisionManager collision_manager)
        {
            _engine = engine;
            _eventManager = event_manager;
            _renderManager = render_manager;
            _collisionManager = collision_manager;
        }

        public void Run()
        {
            GameObject world = new GameObject("Tamriel", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(world);
            CollisionComponent world_collision_comp = new CollisionComponent(world, _engine, _eventManager, _renderManager, _collisionManager);
            WorldComponent world_component = new WorldComponent(world, _engine, _eventManager, _renderManager, 20, 20, _collisionManager, world_collision_comp);

            GameObject skyrim = new GameObject("Skyrim", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(skyrim);
            TransformComponent skyrim_transform_comp = new TransformComponent(skyrim, _engine, _eventManager, _renderManager);
            CollisionComponent skyrim_collision_comp = new CollisionComponent(skyrim, _engine, _eventManager, _renderManager, _collisionManager);
            RegionComponent skyrim_region_comp = new RegionComponent(skyrim, _engine, _eventManager, _renderManager, 20, 20, _collisionManager, skyrim_collision_comp);

            VisualRenderComponent skyrim_visual_render_comp = new VisualRenderComponent(skyrim, _engine, _eventManager, skyrim_transform_comp, "S ", _renderManager);
            skyrim_transform_comp.SetPosition(1, 6);
            GameObject windhelm = new GameObject("WindHelm", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(windhelm);
            TransformComponent windhelm_transform_comp = new TransformComponent(windhelm, _engine, _eventManager, _renderManager);
            CollisionComponent windhelm_collision_comp = new CollisionComponent(windhelm, _engine, _eventManager, _renderManager, _collisionManager);
            CityComponent city_windhelm_comp = new CityComponent(windhelm, _engine, _eventManager, _renderManager, 20, 20, _collisionManager, windhelm_collision_comp);
            VisualRenderComponent windhelm_visual_render_comp = new VisualRenderComponent(windhelm, _engine, _eventManager, windhelm_transform_comp, "WI", _renderManager);
            windhelm_transform_comp.SetPosition(6, 1);
            GameObject whiterun = new GameObject("Whiterun", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(whiterun);
            TransformComponent whiterun_transform_comp = new TransformComponent(whiterun, _engine, _eventManager, _renderManager);
            CollisionComponent whiterun_collision_comp = new CollisionComponent(whiterun, _engine, _eventManager, _renderManager, _collisionManager);
            CityComponent city_whiterun_comp = new CityComponent(whiterun, _engine, _eventManager, _renderManager, 20, 20, _collisionManager, whiterun_collision_comp);
            VisualRenderComponent whiterun_visual_render_comp = new VisualRenderComponent(whiterun, _engine, _eventManager, whiterun_transform_comp, "WH", _renderManager);
            whiterun_transform_comp.SetPosition(15, 2);
            GameObject cyrodiil = new GameObject("Cyrodiil", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(cyrodiil);
            TransformComponent cyrodiil_transform_comp = new TransformComponent(cyrodiil, _engine, _eventManager, _renderManager);
            CollisionComponent cyrodiil_collision_comp = new CollisionComponent(cyrodiil, _engine, _eventManager, _renderManager, _collisionManager);
            RegionComponent region_cyrodiil_comp = new RegionComponent(cyrodiil, _engine, _eventManager, _renderManager, 20, 20, _collisionManager, cyrodiil_collision_comp);
            cyrodiil_transform_comp.SetPosition(5, 5);
            VisualRenderComponent cyrodiil_visual_render_comp = new VisualRenderComponent(cyrodiil, _engine, _eventManager, cyrodiil_transform_comp, "C ", _renderManager);

            GameObject imperial_city = new GameObject("Imperial City", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(imperial_city);
            TransformComponent imperial_transform_comp = new TransformComponent(imperial_city, _engine, _eventManager, _renderManager);
            CollisionComponent imperial_collision_comp = new CollisionComponent(imperial_city, _engine, _eventManager, _renderManager, _collisionManager);
            CityComponent city_imperial_city_comp = new CityComponent(imperial_city, _engine, _eventManager, _renderManager, 20, 20, _collisionManager, imperial_collision_comp);
            VisualRenderComponent imperial_visual_render_comp = new VisualRenderComponent(imperial_city, _engine, _eventManager, imperial_transform_comp, "I ", _renderManager);
            GameObject kvatch = new GameObject("Kvatch", _engine, _eventManager, _renderManager);
            imperial_transform_comp.SetPosition(16, 5);
            _engine.RegisterGameObject(kvatch);
            TransformComponent kvatch_transform_comp = new TransformComponent(kvatch, _engine, _eventManager, _renderManager);
            CollisionComponent kvatch_collision_comp = new CollisionComponent(kvatch, _engine, _eventManager, _renderManager, _collisionManager);
            CityComponent city_kvatch_comp = new CityComponent(kvatch, _engine, _eventManager, _renderManager, 20, 20, _collisionManager, kvatch_collision_comp);
            VisualRenderComponent kvatch_visual_render_comp = new VisualRenderComponent(kvatch, _engine, _eventManager, kvatch_transform_comp, "K ", _renderManager);
            kvatch_transform_comp.SetPosition(14, 2);
            skyrim_region_comp.AddLocation(city_windhelm_comp);
            skyrim_region_comp.AddLocation(city_whiterun_comp);

            region_cyrodiil_comp.AddLocation(city_imperial_city_comp);
            region_cyrodiil_comp.AddLocation(city_kvatch_comp);

            world_component.AddLocation(skyrim_region_comp);
            world_component.AddLocation(region_cyrodiil_comp);

            GameObject player = new GameObject("player", _engine, _eventManager, _renderManager);
            _engine.RegisterGameObject(player);
            player.AddComponent(new TransformComponent(player, _engine, _eventManager, _renderManager));
            player.AddComponent(new CharacterComponent(player, _engine, _eventManager, _renderManager));
            player.AddComponent(new VisualRenderComponent(player, _engine, _eventManager, player.GetComponent<TransformComponent>(), "P ", _renderManager));
            player.GetComponent<TransformComponent>().SetPosition(10, 10);
            player.AddComponent(new CollisionComponent(player, _engine, _eventManager, _renderManager, _collisionManager));
            player.AddComponent(new MovementComponent(player, _engine, _eventManager, _renderManager, player.GetComponent<TransformComponent>()));
            player.AddComponent(new InputComponent(player, _engine, _eventManager, _renderManager, player.GetComponent<MovementComponent>()));
            _collisionManager.RegisterCollisionComponent(player.GetComponent<CollisionComponent>());
            InventoryComponent player_inventory = new InventoryComponent(player, _engine, _eventManager, _renderManager);
            GameObject apple = new GameObject("Apple", _engine, _eventManager, _renderManager);
            apple.AddComponent(new ItemComponent(apple, _engine, _eventManager, "Apple", 10, 5, _renderManager));
            GameObject water = new GameObject("Water", _engine, _eventManager, _renderManager);
            water.AddComponent(new ItemComponent(water, _engine, _eventManager, "Water", 100, 1, _renderManager));
            player_inventory.AddItem(apple.GetComponent<ItemComponent>());
            player_inventory.AddItem(water.GetComponent<ItemComponent>());

            world_component.Enter(player);
        }
    }
}

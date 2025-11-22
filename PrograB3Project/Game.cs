using PrograB3Project.Components;
using PrograB3Project.Components.Rendering;
using PrograB3Project.Data;
using PrograB3Project.Events;
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
        private SaveManager _saveManager;
        private Dictionary<string, LocationComponent> _locationsTable = new Dictionary<string, LocationComponent>();
        private string _saveFileRelativePath = "../../../Data/SaveFile.sav";
        private string _worldDataFileRelativePath = "../../../Data/WorldDataBase.csv";
        private string _keylocationDataFileRelativePath = "../../../Data/KeyLocationsDataBase.csv";
        private string _playerInventoryDataFileRelativePath = "../../../Data/PlayerInventoryDataBase.csv";

        public Game(Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager, RenderManager render_manager, CollisionManager collision_manager)
        {
            _engine = engine;
            _eventManager = event_manager;
            _renderManager = render_manager;
            _collisionManager = collision_manager;
            _saveManager = new SaveManager(_eventManager, _saveFileRelativePath);
            _eventManager.RegisterEvent<QuitGameEvent>(OnQuitGameEvent);
        }

        public void Run()
        {
            CreateWorlds();

            GameObject player = CreatePlayer();

            try
            {
                _saveManager.LoadSaveFile();
            }

            catch (Exception generic_exception)
            {

            }
            _locationsTable["World_00"].Enter(player);
        }

        //Possibility of making switch case more flexible but not top priority
        private void CreateWorlds()
        {
            GenericDataBase world_data_base = new GenericDataBase();
            world_data_base.LoadDataFromCSV(_worldDataFileRelativePath);
            GenericDataBase keylocations_data_base = new GenericDataBase();
            keylocations_data_base.LoadDataFromCSV(_keylocationDataFileRelativePath);
            List<KeyValuePair<string, string>> worlds_value_table = world_data_base.GetData();
            List<KeyValuePair<string, string>> keylocations_value_table = keylocations_data_base.GetData();

            foreach (KeyValuePair<string, string> world_data in worlds_value_table)
            {
                string[] split_value = world_data.Value.Split(";");

                switch (split_value[1])
                {

                    case "World":
                        {
                            GameObject world = new GameObject(split_value[2], _eventManager);
                            _engine.RegisterGameObject(world);
                            TransformComponent world_transform = new TransformComponent(world);
                            CollisionComponent world_coll_comp = new CollisionComponent(world, _eventManager, _collisionManager, world_transform);
                            WorldComponent world_comp = new WorldComponent(world, _eventManager, _renderManager, 20, 20, _collisionManager, world_coll_comp, split_value[0]);
                            _locationsTable.Add(split_value[0], world_comp);
                            break;
                        }

                    case "Region":
                        {
                            GameObject region = new GameObject(split_value[2], _eventManager);
                            _engine.RegisterGameObject(region);
                            TransformComponent region_transform_comp = new TransformComponent(region);
                            region_transform_comp.SetPosition((new Random().Next() % 17) + 2, (new Random().Next() % 17) + 2);
                            VisualRenderComponent visual_render_comp = new VisualRenderComponent(region, region_transform_comp, split_value[4], _renderManager);
                            CollisionComponent region_coll_comp = new CollisionComponent(region, _eventManager, _collisionManager, region_transform_comp);
                            RegionComponent region_comp = new RegionComponent(region, _eventManager, _renderManager, 20, 20, _collisionManager, region_coll_comp, split_value[0]);
                            _locationsTable.Add(split_value[0], region_comp);

                            if (_locationsTable.ContainsKey(split_value[3]))
                            {
                                _locationsTable[split_value[3]].AddLocation(region_comp);
                            }
                            break;
                        }

                    case "City":
                        {
                            GameObject city = new GameObject(split_value[2], _eventManager);
                            _engine.RegisterGameObject(city);
                            TransformComponent city_transform_comp = new TransformComponent(city);
                            city_transform_comp.SetPosition((new Random().Next() % 17) + 2, (new Random().Next() % 17) + 2);
                            VisualRenderComponent visual_render_comp = new VisualRenderComponent(city, city_transform_comp, split_value[4], _renderManager);
                            CollisionComponent city_coll_comp = new CollisionComponent(city, _eventManager, _collisionManager, city_transform_comp);
                            CityComponent city_comp = new CityComponent(city, _eventManager, _renderManager, 20, 20, _collisionManager, city_coll_comp, split_value[0]);
                            _locationsTable.Add(split_value[0], city_comp);
                            _locationsTable[split_value[3]].AddLocation(city_comp);
                            break;
                        }
                }
            }
            Dictionary<string, InventoryComponent> keylocations_inventory_table = new Dictionary<string, InventoryComponent>();

            foreach (KeyValuePair<string, string> keylocation_data in keylocations_value_table)
            {
                string[] split_value = keylocation_data.Value.Split(";");

                switch (split_value[1])
                {

                    case "Shop":
                        {

                            if (_locationsTable.ContainsKey(split_value[3]))
                            {
                                GameObject shop = new GameObject(split_value[2], _eventManager);
                                TransformComponent shop_transform_comp = new TransformComponent(shop);
                                shop_transform_comp.SetPosition((new Random().Next() % 17) + 2, (new Random().Next() % 17) + 2);
                                InventoryComponent shop_inventory = new InventoryComponent(shop, _eventManager);
                                CollisionComponent shop_collision_comp = new CollisionComponent(shop, _eventManager, _collisionManager, shop_transform_comp);
                                TradingComponent shop_trading_comp = new TradingComponent(shop);
                                ShopComponent shop_component = new ShopComponent(shop,_engine, _eventManager, _locationsTable[split_value[3]], shop_trading_comp, shop_inventory, _renderManager, shop_collision_comp, shop_transform_comp);
                                CityComponent parent_city = (CityComponent)_locationsTable[split_value[3]];
                                ShopBuyingStateRenderComponent shop_buying_render_comp = new ShopBuyingStateRenderComponent(shop, _renderManager, shop_inventory);
                                ShopSellingStateRenderComponent shop_selling_render_comp = new ShopSellingStateRenderComponent(shop, _renderManager, shop_inventory);
                                VisualRenderComponent shop_visual_comp = new VisualRenderComponent(shop, shop_transform_comp, "SH", _renderManager);
                                parent_city.AddLocation(shop_component);
                                keylocations_inventory_table.Add(split_value[0], shop_inventory);
                            }
                            break;
                        }

                    case "Item":
                        {

                            if (keylocations_inventory_table.ContainsKey(split_value[3]))
                            {
                                GameObject item = new GameObject(split_value[0], _eventManager);
                                ItemComponent item_comp = new ItemComponent(item, split_value[2], int.Parse(split_value[5]), int.Parse(split_value[4]));
                                keylocations_inventory_table[split_value[3]].AddItem(item_comp);
                            }
                            break;
                        }

                    case "Job":
                        {

                            if (_locationsTable.ContainsKey(split_value[3]))
                            {
                                GameObject job = new GameObject(split_value[0], _eventManager);
                                TransformComponent job_transform = new TransformComponent(job);
                                job_transform.SetPosition((new Random().Next() % 17) + 2, (new Random().Next() % 17) + 2);
                                CollisionComponent job_collision_comp = new CollisionComponent(job, _eventManager, _collisionManager, job_transform);
                                VisualRenderComponent job_visual_comp = new VisualRenderComponent(job, job_transform, "J ", _renderManager);
                                JobRenderComponent job_render_comp = new JobRenderComponent(job, "", _renderManager);
                                JobComponent job_comp = new JobComponent(job, _eventManager, _locationsTable[split_value[3]], _renderManager, job_collision_comp, job_transform, job_render_comp);
                                CityComponent parent_city = (CityComponent)_locationsTable[split_value[3]];
                                parent_city.AddLocation(job_comp);
                            }
                            break;
                        }
                }
            }
        }

        private GameObject CreatePlayer()
        {
            GameObject player = new GameObject("Player", _eventManager);
            _engine.RegisterGameObject(player);
            TransformComponent player_transform = new TransformComponent(player);
            player_transform.SetPosition(10, 10);
            CharacterComponent player_character_comp = new CharacterComponent(player);
            VisualRenderComponent player_visual_render_comp = new VisualRenderComponent(player, player_transform, "P ", _renderManager);
            CollisionComponent player_collision_comp = new CollisionComponent(player, _eventManager, _collisionManager, player_transform);
            MovementComponent player_movement_comp = new MovementComponent(player, player_transform);
            InputComponent player_input_comp = new InputComponent(player, _eventManager, player_movement_comp);
            _collisionManager.RegisterCollisionComponent(player_collision_comp);
            InventoryComponent player_inventory = new InventoryComponent(player, _eventManager);
            GenericDataBase player_inventory_data_base = new GenericDataBase();
            player_inventory_data_base.LoadDataFromCSV(_playerInventoryDataFileRelativePath);
            List<KeyValuePair<string, string>> inventory_data = player_inventory_data_base.GetData();

            foreach (KeyValuePair<string, string> item_data in inventory_data)
            {
                string[] item_values = item_data.Value.Split(';');
                GameObject item = new GameObject(item_values[2], _eventManager);
                ItemComponent item_comp = new ItemComponent(item, item_values[2], int.Parse(item_values[3]), int.Parse(item_values[4]));
                player_inventory.AddItem(item.GetComponent<ItemComponent>());
            }

            return player;
        }

        public void OnQuitGameEvent(Events.Event exit_event)
        {
            _saveManager.Save();
        }
    }
}

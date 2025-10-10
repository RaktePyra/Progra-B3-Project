using PrograB3Project.Components.Rendering;
using PrograB3Project.Interfaces;

namespace PrograB3Project.Components
{
    internal class CityComponent : LocationComponent
    {
        private List<KeyLocationComponent> _locationTable = new List<KeyLocationComponent>();

        public CityComponent(Interfaces.IGameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager, RenderManager render_manager, int level_size_x, int level_size_y, CollisionManager collision_manager, CollisionComponent collision_component, string id) : base(owner, engine, event_manager, render_manager, level_size_x, level_size_y, collision_manager, collision_component,id)
        {
            //Interfaces.IGameObject shop = new GameObject("Shop", engine, event_manager, render_manager);
            //InventoryComponent shop_inventory = new InventoryComponent(shop, engine, event_manager, render_manager);
            //shop_inventory.AddMoney(9900);
            //Interfaces.IGameObject sword = new GameObject("Sword", engine, event_manager, render_manager);
            //ItemComponent sword_comp = new ItemComponent(sword, engine, event_manager, "sword", 1, 10, render_manager);
            //shop_inventory.AddItem(sword_comp);
            //TradingComponent shop_trading_comp = new TradingComponent(shop, engine, event_manager, render_manager);
            //TransformComponent shop_transform_comp = new TransformComponent(shop, engine, event_manager, render_manager);
            //shop_transform_comp.SetPosition(2, 5);
            //CollisionComponent shop_collision_component = new CollisionComponent(shop, engine, event_manager, render_manager, collision_manager);
            //ShopComponent shop_component = new(shop, engine, event_manager, this, shop_trading_comp, shop_inventory, render_manager, shop_collision_component);
            //ShopBuyingStateRenderComponent shop_buying_render_comp = new ShopBuyingStateRenderComponent(shop, _gameEngine, _eventManager, _renderManager, shop_inventory);
            //ShopSellingStateRenderComponent shop_selling_render_comp = new ShopSellingStateRenderComponent(shop, _gameEngine, _eventManager, _renderManager, shop_inventory);
            //VisualRenderComponent shop_visual_comp = new VisualRenderComponent(shop, engine, event_manager, shop_transform_comp, "SH", render_manager);
            //AddLocation(shop_component);

            //Interfaces.IGameObject job = new GameObject("Grind Shrine", engine, event_manager, render_manager);

            //CollisionComponent shrine_collision_comp = new CollisionComponent(job,engine,event_manager,render_manager,collision_manager);
            //JobComponent grind_shrine = new JobComponent(job, engine, event_manager, this, render_manager, collision_component);
            //AddLocation(grind_shrine);
        }

        public void AddLocation(KeyLocationComponent location)
        {
            if (!_locationTable.Contains(location))
            {
                _locationTable.Add(location);
                VisualRenderComponent location_visual_comp = location.GetOwnerGameObject().GetComponent<VisualRenderComponent>();
                if (location_visual_comp != null)
                {
                    _levelRenderComponent.AddLocationRenderComponent(location_visual_comp);
                }
            }
        }

        public override void Enter(IGameObject player)
        {
            base.Enter(player);
            foreach(KeyLocationComponent location in _locationTable)
            {
                location.OnParentLocationEntered();
            }
        }
    }
}

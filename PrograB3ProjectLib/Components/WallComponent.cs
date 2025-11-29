using PrograB3Project.Interfaces;

namespace PrograB3Project.Components
{
    public class WallComponent : Component
    {
        private CollisionComponent _collisionComponent;
        private TransformComponent _transformComponent;
        private CollisionManager _collisionManager;
        private LocationComponent _locationComponent;
        private IEventManager _eventManager;
        public WallComponent(IGameObject owner, IEventManager event_manager, CollisionManager collision_manager, int x_coordinate, int y_coordinate, LocationComponent locationComponent) : base(owner)
        {
            _eventManager = event_manager;
            _transformComponent = new TransformComponent(owner);
            _collisionComponent = new CollisionComponent(owner, event_manager, collision_manager,_transformComponent);
            _transformComponent.SetPosition(x_coordinate, y_coordinate);
            _collisionManager = collision_manager;
            _eventManager.RegisterEvent<Events.CollisionEvent>(OnCollisionEnter);
            _locationComponent = locationComponent;
        }

        public void EnableWall()
        {
            _collisionManager.RegisterCollisionComponent(_collisionComponent);
        }

        public void DisableWall()
        {
            _collisionManager.UnregisterCollisionComponent(_collisionComponent);
        }
        public void OnCollisionEnter(Events.Event collision_event)
        {
            Events.CollisionEvent true_event = collision_event as Events.CollisionEvent;
            if (true_event.IsPartOfCollision(_collisionComponent))
            {
                _locationComponent.Exit();
                
            }
        }

    }
}

using PrograB3Project.Interfaces;

namespace PrograB3Project.Components
{
    public class CollisionComponent : Component
    {
#warning Replace implicit dependency when got time;
        private TransformComponent _ownerTransformComponent;
        private CollisionManager _collisionManager;

        public CollisionComponent(IGameObject owner, IGameEngine engine, IEventManager event_manager, RenderManager render_manager, CollisionManager collision_manager) : base(owner, engine, event_manager, render_manager)
        {
            _ownerTransformComponent = owner.GetComponent<TransformComponent>();
            _collisionManager = collision_manager;
            
        }

        public bool CanMove(LocationCoordinates location)
        {
            bool result = true;
            CollisionComponent colliding_comp = _collisionManager.GetCollisionComponentAtLocation(location);
            if (colliding_comp != null)
            {
                result = false;
                _eventManager.TriggerEvent(new Events.CollisionEvent(this,colliding_comp));
            }
            return result;
        }

        public LocationCoordinates GetTransform()
        {
            return _ownerTransformComponent.GetLocationCoordinates();
        }

        public CollisionManager GetCollisionManager()
        {
            return _collisionManager;
        }
    }
}

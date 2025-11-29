using PrograB3Project.Events;

namespace PrograB3Project.Components
{
    public class KeyLocationComponent : Component
    {
        protected LocationComponent _parentLocation;
        protected CollisionComponent _collisionComponent;
        protected TransformComponent _transformComponent;
        protected Interfaces.IEventManager _eventManager;

        public KeyLocationComponent(Interfaces.IGameObject owner, Interfaces.IEventManager event_manager, LocationComponent parent_location, CollisionComponent collision_component, TransformComponent transformComponent) : base(owner)
        {
            _parentLocation = parent_location;
            _collisionComponent = collision_component;
            _transformComponent = transformComponent;
            _eventManager = event_manager;
        }

        public virtual void Enter(Interfaces.IGameObject player)
        {
            player.GetComponent<InputComponent>().BeginInteraction(this);
            _parentLocation.EnterChildLocation();
            _collisionComponent.GetCollisionManager().UnregisterCollisionComponent(_collisionComponent);
            _eventManager.UnregisterFromEvent<CollisionEvent>(OnCollisionEnter);
        }

        public virtual void Exit(Interfaces.IGameObject player)
        {
            _parentLocation.Enter(player);

        }

        public virtual void OnCollisionEnter(Event collision_event)
        {
            CollisionEvent true_event = collision_event as CollisionEvent;
            if (true_event.IsPartOfCollision(_collisionComponent))
            {
                OnCollisionEnter(true_event.GetOtherCollisionComponent(_collisionComponent));
            }
        }

        public virtual void OnCollisionEnter(CollisionComponent collider)
        {
            Enter(collider.GetOwnerGameObject());
        }

        public void OnParentLocationEntered()
        {
            _collisionComponent.GetCollisionManager().RegisterCollisionComponent(_collisionComponent);
            _eventManager.RegisterEvent<CollisionEvent>(OnCollisionEnter);
        }
    }
}

using PrograB3Project.Components.Rendering;
using PrograB3Project.Events;

namespace PrograB3Project.Components
{
    public class KeyLocationComponent : Component
    {
        protected LocationComponent _parentLocation;
        protected TextualRenderComponent _textualRenderComponent;
        protected VisualRenderComponent _visualRenderComponent;
        protected CollisionComponent _collisionComponent;


        public KeyLocationComponent(Interfaces.IGameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager, LocationComponent parent_location, RenderManager render_manager, CollisionComponent collision_component) : base(owner, engine, event_manager, render_manager)
        {
            _parentLocation = parent_location;
            owner.AddComponent(this);
            _textualRenderComponent = new TextualRenderComponent(owner, engine, event_manager, "Basic Textual Render Component", render_manager);
            _collisionComponent = collision_component;
        }

        public virtual void Enter(Interfaces.IGameObject player)
        {
            player.GetComponent<InputComponent>().BeginInteraction(this);
            _parentLocation.EnterChildLocation();
            _renderManager.RegisterRenderComponent(_textualRenderComponent);
            _renderManager.UnregisterRenderComponent(_visualRenderComponent);
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
            _renderManager.RegisterRenderComponent(_visualRenderComponent);
            _collisionComponent.GetCollisionManager().RegisterCollisionComponent(_collisionComponent);
            _eventManager.RegisterEvent<CollisionEvent>(OnCollisionEnter);
        }
    }
}

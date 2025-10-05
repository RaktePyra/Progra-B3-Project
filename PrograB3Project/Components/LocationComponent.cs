using PrograB3Project.Components.Rendering;
using PrograB3Project.Events;

namespace PrograB3Project.Components
{
    public class LocationComponent : Component
    {
        protected LocationComponent _parentLocation;
        protected LevelRenderComponent _levelRenderComponent;
        protected TransformComponent _inWorldTransformComponent;
        protected CollisionManager _collisionManager;
        protected CollisionComponent _collisionComponent;
        private int _levelSizeX = 0;
        private int _levelSizeY = 0;
        protected List<LocationComponent> _childLocationTable = new List<LocationComponent>();
        private Interfaces.IGameObject _player;

        public LocationComponent(Interfaces.IGameObject owner, Interfaces.IGameEngine game_engine, Interfaces.IEventManager event_manager, RenderManager render_manager, int levelSizeX, int levelSizeY, CollisionManager collision_manager,CollisionComponent collision_component) : base(owner, game_engine, event_manager, render_manager)
        {
            _levelSizeX = levelSizeX;
            _levelSizeY = levelSizeY;
            _levelRenderComponent = new LevelRenderComponent(owner, game_engine, event_manager, render_manager, this, _levelSizeX, _levelSizeY);
            _collisionManager = collision_manager;
            _collisionComponent = collision_component;
            _eventManager.RegisterEvent<CollisionEvent>(OnCollision);
        }

        public virtual void Enter(Interfaces.IGameObject player)
        {
            if (_parentLocation != null)
            {
                _parentLocation.Exit();
            }
            _collisionManager.UnregisterCollisionComponent(_collisionComponent);
            _renderManager.RegisterRenderComponent(_levelRenderComponent);
            _player = player;
            InputComponent player_input_comp = _player.GetComponent<InputComponent>();
            VisualRenderComponent player_visual_comp = _player.GetComponent<VisualRenderComponent>();
            _levelRenderComponent.SetPlayerVisualRendererComponent(player_visual_comp);

            if (player_input_comp != null)
            {
                player_input_comp.BeginInteraction(this);
            }
            else
            {
                throw new Exception("A Player was not provided to " + this.ToString());
            }
            foreach (LocationComponent child_location in _childLocationTable)
            {
                child_location.OnParentLocationEntered();
            }
        }

        public void AddLocation(LocationComponent location)
        {
            location._parentLocation = this;

            if (!_childLocationTable.Contains(location))
            {
                _childLocationTable.Add(location);
                _levelRenderComponent.AddLocationRenderComponent(location.GetOwnerGameObject().GetComponent<VisualRenderComponent>());
            }
        }

        public Interfaces.IGameObject GetPlayer()
        {
            return _player;
        }

        public virtual void Exit()
        {
            _renderManager.UnregisterRenderComponent(_levelRenderComponent);
            _collisionManager.UnregisterCollisionComponent(_collisionComponent);
            
        }

        public override void ProcessInput(ConsoleKeyInfo key)
        {
            int user_choice = (int)key.Key - (int)ConsoleKey.NumPad1;

            if (user_choice >= 0 && user_choice < _childLocationTable.Count)
            {
                _childLocationTable[user_choice].Enter(GetPlayer());
            }

            else if (user_choice == _childLocationTable.Count)
            {
                Console.Clear();
                _parentLocation.Enter(GetPlayer());
            }

        }

        public void OnCollision(Events.Event collision_event)
        {
            CollisionEvent temp_event = collision_event as CollisionEvent;
            if (temp_event.IsPartOfCollision(_collisionComponent) == true)
            {
                OnCollisionEnter(temp_event.GetOtherCollisionComponent(_collisionComponent));
            }
        }

        public virtual void OnCollisionEnter(CollisionComponent collider)
        {

        }

        public virtual void OnParentLocationEntered()
        {
            _collisionManager.RegisterCollisionComponent(_collisionComponent);
        }
    }
}

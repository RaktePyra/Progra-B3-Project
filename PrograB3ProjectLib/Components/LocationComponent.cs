
using PrograB3Project.Events;
using System;
using System.Collections.Generic;
namespace PrograB3Project.Components
{
    public class LocationComponent : Component
    {

        protected Interfaces.IEventManager _eventManager;
        private string _id;
        protected LocationComponent _parentLocation;
        protected TransformComponent _inWorldTransformComponent;
        protected CollisionManager _collisionManager;
        protected CollisionComponent _collisionComponent;
        private int _levelSizeX = 0;
        private int _levelSizeY = 0;
        protected List<LocationComponent> _childLocationTable = new List<LocationComponent>();
        protected List<WallComponent> _wallTable = new List<WallComponent>();
        private Interfaces.IGameObject _player;

        public LocationComponent(Interfaces.IGameObject owner, Interfaces.IEventManager event_manager, int levelSizeX, int levelSizeY, CollisionManager collision_manager, CollisionComponent collision_component,string id) : base(owner)
        {
            _eventManager = event_manager;
            _id = id;
            _levelSizeX = levelSizeX;
            _levelSizeY = levelSizeY;
            _collisionManager = collision_manager;
            _collisionComponent = collision_component;
            _eventManager.RegisterEvent<CollisionEvent>(OnCollision);
            CreateWalls();
        }

        public virtual void Enter(Interfaces.IGameObject player)
        {
            if (_parentLocation != null)
            {
                _parentLocation.EnterChildLocation();
            }
            _collisionManager.UnregisterCollisionComponent(_collisionComponent);
            _player = player;
            InputComponent player_input_comp = _player.GetComponent<InputComponent>();

            if (player_input_comp != null)
            {
                player_input_comp.BeginInteraction(this);
            }

            else
            {
                throw new System.Exception("A Player was not provided to " + this.ToString());
            }

            foreach (LocationComponent child_location in _childLocationTable)
            {
                child_location.OnParentLocationEntered();
            }
            
            foreach(WallComponent wall_component in _wallTable)
            {
                wall_component.EnableWall();
            }
        }

        public void AddLocation(LocationComponent location)
        {
            location._parentLocation = this;

            if (!_childLocationTable.Contains(location))
            {
                _childLocationTable.Add(location);
            }
        }

        public Interfaces.IGameObject GetPlayer()
        {
            return _player;
        }

        public virtual void Exit()
        {
            _collisionManager.UnregisterCollisionComponent(_collisionComponent);

            foreach (WallComponent wall_component in _wallTable)
            {
                wall_component.DisableWall();
            }
            _parentLocation.Enter(_player);
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
            Enter(collider.GetOwnerGameObject());
        }

        public virtual void OnParentLocationEntered()
        {
            _collisionManager.RegisterCollisionComponent(_collisionComponent);
        }

        public void CreateWalls()
        {
            for (int x_index = 0; x_index < _levelSizeX; x_index++)
            {
                for (int y_index = 0; y_index < _levelSizeY; y_index++)
                {
                    if (x_index == 0 || y_index == 0 || x_index == _levelSizeX - 1 || y_index == _levelSizeY - 1)
                    {
                        _wallTable.Add(new WallComponent(GetOwnerGameObject(), _eventManager, _collisionManager, x_index, y_index,this));
                    }
                }
            }
        }

        public virtual void EnterChildLocation()
        {
           _collisionManager.UnregisterCollisionComponent(_collisionComponent);

            foreach (WallComponent wall_component in _wallTable)
            {
                wall_component.DisableWall();
            }
        }
    }
}

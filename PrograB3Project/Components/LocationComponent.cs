using PrograB3Project.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class LocationComponent : Component
    { 
        protected LocationComponent _parentLocation;
        protected LevelRenderComponent _levelRenderComponent;
        protected TransformComponent _inWorldTransformComponent;
        protected CollisionManager _collisionManager;
        private int _levelSizeX = 0;
        private int _levelSizeY = 0;
        protected List<LocationComponent> _childLocationTable = new List<LocationComponent>();
        private Interfaces.IGameObject _player;
       
        public LocationComponent(Interfaces.IGameObject owner, Interfaces.IGameEngine game_engine, Interfaces.IEventManager event_manager, RenderManager render_manager, int levelSizeX, int levelSizeY,CollisionManager collisionManager) : base(owner, game_engine, event_manager, render_manager)
        {
            _levelSizeX = levelSizeX;
            _levelSizeY = levelSizeY;
            _levelRenderComponent = new LevelRenderComponent(owner, game_engine, event_manager, render_manager,this, _levelSizeX, _levelSizeY);
            _collisionManager = collisionManager;
        }

        public virtual void Enter(Interfaces.IGameObject player)
        {
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
                Console.Clear();
                _parentLocation.Enter(GetPlayer());
            }

        }
    }
}

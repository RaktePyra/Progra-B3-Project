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
        protected List<LocationComponent> _childLocationTable = new List<LocationComponent>();
        private GameObject _player;
       
        public LocationComponent(GameObject owner, GameEngine game_engine, Events.EventManager event_manager) : base(owner, game_engine,event_manager)
        {
        }

        public virtual void Enter(GameObject player)
        {
            _player = player;
            InputComponent player_input_comp = _player.GetComponent<InputComponent>();

            if (player_input_comp != null)
            {
                player_input_comp.BeginInteraction(this);
            }
            else
            {
                throw new Exception("A Player was not provided to " + this.ToString());
            }

        }

        public virtual void AddLocation(LocationComponent location)
        {
            location._parentLocation = this;
            
            if (!_childLocationTable.Contains(location))
            {
                _childLocationTable.Add(location);
            }
        }

        public GameObject GetPlayer()
        {
            return _player;
        }

        public virtual void Exit()
        {
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

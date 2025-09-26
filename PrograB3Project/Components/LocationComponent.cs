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
        private GameObject _player;
       
        public LocationComponent(GameObject owner,Context game_context) : base(owner,game_context)
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
        }

        public GameObject GetPlayer()
        {
            return _player;
        }

        public virtual void Exit()
        {
            _parentLocation.Enter(_player);
        }
    }
}

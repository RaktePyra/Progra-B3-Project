using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class LocationComponent : Component
    {
        private GameObject _player;
        private LocationComponent _parentLocation;
        public LocationComponent(GameObject owner) : base(owner)
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
        }
    }
}

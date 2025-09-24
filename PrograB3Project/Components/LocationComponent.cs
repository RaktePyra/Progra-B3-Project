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
        public LocationComponent(GameObject owner) : base(owner)
        {
        }

        public virtual void Enter(GameObject player)
        {
            _player = player;
        }

        public virtual void AddLocation(LocationComponent location)
        {

        }

        public virtual void ProcessInput(ConsoleKeyInfo key)
        {

        }

        public GameObject GetPlayer()
        {
            return _player;
        }
    }
}

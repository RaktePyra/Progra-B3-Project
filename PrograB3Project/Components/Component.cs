using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class Component
    {
        private GameObject _ownerGameObject;
        public Component(GameObject owner)
        {
            _ownerGameObject = owner;
        }
        public void Update(float delta_time)
        {

        }

        public GameObject GetOwnerGameObject()
        {
            return _ownerGameObject;
        }
    }
}

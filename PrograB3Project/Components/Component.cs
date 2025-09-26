using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class Component
    {
        protected Context _gameContext;
        private GameObject _ownerGameObject;
        
        public Component(GameObject owner, Context gameContext)
        {
            _ownerGameObject = owner;
            _gameContext = gameContext;
            _ownerGameObject.AddComponent(this);
        }
        public void Update(float delta_time)
        {

        }

        public GameObject GetOwnerGameObject()
        {
            return _ownerGameObject;
        }

        public virtual void ProcessInput(ConsoleKeyInfo key)
        {

        }
    }
}

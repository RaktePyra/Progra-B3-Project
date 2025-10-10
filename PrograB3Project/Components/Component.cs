using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class Component : IComponent
    {
        protected IGameObject _ownerGameObject;
        
        public Component(IGameObject owner)
        {
            _ownerGameObject = owner;
            _ownerGameObject.AddComponent(this);

        }

        public void Update(float delta_time)
        {

        }

        public IGameObject GetOwnerGameObject()
        {
            return _ownerGameObject;
        }

        public virtual void ProcessInput(ConsoleKeyInfo key)
        {

        }

        public virtual string Serialize()
        {
            return ToString();
        }
    }
}

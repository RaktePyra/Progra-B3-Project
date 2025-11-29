using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Interfaces
{
    public interface IComponent
    {
        public void Update(float delta_time);


        public Interfaces.IGameObject GetOwnerGameObject();

        public abstract void ProcessInput(ConsoleKeyInfo key);
    }
}

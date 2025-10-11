using PrograB3Project.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrograB3Project.Interfaces
{
    public interface IGameObject
    {
        public void Update(float delta_time);

        public void AddComponent(IComponent component);

        public TYPE GetComponent<TYPE>() where TYPE : IComponent;

        public string GetName();

        public int GetComponentCount();
    }
}

using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class TransformComponent : Component
    {
        public TransformComponent(IGameObject owner, IGameEngine engine, IEventManager event_manager) : base(owner, engine, event_manager)
        {
        }
    }
}

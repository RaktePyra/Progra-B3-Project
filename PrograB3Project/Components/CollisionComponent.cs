using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    internal class CollisionComponent : Component
    {
        public CollisionComponent(IGameObject owner, IGameEngine engine, IEventManager event_manager, RenderManager render_manager) : base(owner, engine, event_manager, render_manager)
        {
        }
    }
}

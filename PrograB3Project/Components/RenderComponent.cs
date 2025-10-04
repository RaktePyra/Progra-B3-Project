using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public abstract class RenderComponent : Component
    {
        protected RenderManager _renderManager;
        protected RenderComponent(IGameObject owner, IGameEngine engine, IEventManager event_manager, RenderManager render_manager) : base(owner, engine, event_manager,render_manager)
        {
            _renderManager = render_manager;
        }

        public abstract void Render();
    }
}

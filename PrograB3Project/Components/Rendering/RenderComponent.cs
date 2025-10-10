using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components.Rendering
{
    public abstract class RenderComponent : Component
    {
        protected RenderManager _renderManager;
        protected RenderComponent(IGameObject owner, RenderManager render_manager) : base(owner)
        {
            _renderManager = render_manager;
        }

        public abstract void Render();
    }
}

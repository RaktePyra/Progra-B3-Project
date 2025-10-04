using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class VisualRenderComponent : RenderComponent
    {
        private TransformComponent _ownerTransform;
        private char _character = ' ';

        public VisualRenderComponent(IGameObject owner, IGameEngine engine, IEventManager event_manager, TransformComponent transformComponent, char character,RenderManager render_manager) : base(owner, engine, event_manager, render_manager)
        {
            _ownerTransform = transformComponent;
            _character = character;
        }

        public override void Render()
        {
         
        }
    }
}

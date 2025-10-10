using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components.Rendering
{
    public class JobRenderComponent : TextualRenderComponent
    {
        public JobRenderComponent(IGameObject owner, IGameEngine engine, IEventManager event_manager, string text, RenderManager render_manager) : base(owner, engine, event_manager, text, render_manager)
        {
        }

        public override void Render()
        {
            Console.WriteLine("You entered the Grind Shrine");
            Console.WriteLine("Press [E] to commit to the grind");
            Console.WriteLine("Press [0] to go back to the city");
        }
    }
}

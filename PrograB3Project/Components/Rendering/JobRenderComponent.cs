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
        public JobRenderComponent(IGameObject owner, string text, RenderManager render_manager) : base(owner, text, render_manager)
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

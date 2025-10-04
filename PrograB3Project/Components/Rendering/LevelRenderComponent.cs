using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components.Rendering
{
    public class LevelRenderComponent : RenderComponent
    {
        private int _sizeX = 0;
        private int _sizeY = 0;
        private LocationComponent _ownerLocationComponent;
        private string _levelName;
        public LevelRenderComponent(IGameObject owner, IGameEngine engine, IEventManager event_manager, RenderManager render_manager,LocationComponent owner_location_component, int sizeX, int sizeY) : base(owner, engine, event_manager, render_manager)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _levelName = owner.GetName();
            _ownerLocationComponent = owner_location_component;
        }

        public override void Render()
        {
            Console.WriteLine("You are in " + _levelName);

            for (int x_index = 0; x_index < _sizeX; x_index++)
            {
                for (int y_index = 0; y_index < _sizeY; y_index++)
                {
                    if (x_index == 0 || y_index == 0 || x_index == _sizeX - 1 || y_index == _sizeY - 1)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

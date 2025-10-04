using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    internal class RegionComponent : LocationComponent
    {
        public RegionComponent(Interfaces.IGameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager, RenderManager render_manager) : base(owner, engine, event_manager,render_manager) 
        {

        }

        public override void Enter(Interfaces.IGameObject player) 
        {
           base.Enter(player);
            Console.Clear();
            Console.WriteLine("Welcome to " + GetOwnerGameObject().GetName() + " Region.");
            Console.WriteLine("Where do you wanna go?");

            for (int city_index = 0; city_index < _childLocationTable.Count; city_index++)
            {
                Console.WriteLine(city_index +1 + "." + _childLocationTable[city_index].GetOwnerGameObject().GetName());
            }
            Console.WriteLine(_childLocationTable.Count + 1 + ".Quit to " + _parentLocation.GetOwnerGameObject().GetName());
        }

    }
}

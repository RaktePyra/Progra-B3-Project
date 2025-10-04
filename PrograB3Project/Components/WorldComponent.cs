using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class WorldComponent : LocationComponent
    {

        public WorldComponent(GameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager, RenderManager render_manager, int level_size_x, int level_size_y) : base(owner, engine, event_manager, render_manager, level_size_x, level_size_y)
        { 

        }

        public override void Enter(Interfaces.IGameObject player)
        {
            base.Enter(player);
            Console.WriteLine("Welcome to " + GetOwnerGameObject().GetName());
            Console.WriteLine("Where do you want to go");

            for( int region_index = 0; region_index < _childLocationTable.Count; region_index ++ )
            {
                Console.WriteLine((region_index + 1) + "." + _childLocationTable[region_index].GetOwnerGameObject().GetName());
            }
            Console.WriteLine(_childLocationTable.Count+1 + ".Quit the game");
        }


        public override void ProcessInput(ConsoleKeyInfo key)
        {
            if (key.Key >= ConsoleKey.NumPad1 && key.Key <= ConsoleKey.NumPad9)
            {
                int user_choice = (int)key.Key - (int)ConsoleKey.NumPad1; // Numpad 1 because - Numpad 1 = -Numpad 0 -1 where -1 is to account for the user input being shifted by 1

                if (user_choice < _childLocationTable.Count && user_choice >= 0 && _childLocationTable[user_choice] != null) //Dereferencing one of the invalid array cells automatically crashes
                {
                    _childLocationTable[user_choice].Enter(GetPlayer());
                }

                else if(user_choice == _childLocationTable.Count)
                {
                    _eventManager.TriggerEvent(new Events.QuitGameEvent());
                }
            }
        }
    }
}

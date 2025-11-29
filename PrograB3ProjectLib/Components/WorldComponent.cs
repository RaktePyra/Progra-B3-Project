
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

        public WorldComponent(GameObject owner, Interfaces.IEventManager event_manager, int level_size_x, int level_size_y, CollisionManager collision_manager, CollisionComponent collision_component,string id) : base(owner, event_manager, level_size_x, level_size_y,collision_manager, collision_component, id)
        { 
            _collisionManager.UnregisterCollisionComponent(_collisionComponent);
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

        public override void Exit()
        {
            _eventManager.TriggerEvent(new Events.QuitGameEvent());
        }
    }
}

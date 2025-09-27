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
        private List<LocationComponent> _regionTable = new List<LocationComponent>();
        private const int MAX_REGION_RANDOM_NUMBER = 3;
        //Idea : Create a vector class that can be used as a parameter to this World to specify inside the vector
        //how many cities would be in a region and using the size of the vector as the number of regions inside the world

        public WorldComponent(GameObject owner,GameEngine engine, Events.EventManager event_manager) : base(owner, engine, event_manager)
        { 

        }

        public override void Enter(GameObject player)
        {
            base.Enter(player);
            Console.WriteLine("Welcome to " + GetOwnerGameObject().GetName());
            Console.WriteLine("Where do you want to go");

            for( int region_index = 0; region_index < _regionTable.Count; region_index ++ )
            {
                Console.WriteLine((region_index + 1) + "." + _regionTable[region_index].GetOwnerGameObject().GetName());
            }
            Console.WriteLine(_regionTable.Count+1 + ".Quit the game");
        }

        public override void AddLocation(LocationComponent location)
        {
            base.AddLocation(location);

           if(!_regionTable.Contains(location))
            {
                _regionTable.Add(location);
            }
           else
            {
                throw new Exception("location already inside world");
            }
        }

        public override void ProcessInput(ConsoleKeyInfo key)
        {
            if (key.Key >= ConsoleKey.NumPad1 && key.Key <= ConsoleKey.NumPad9)
            {
                int user_choice = (int)key.Key - (int)ConsoleKey.NumPad1; // Numpad 1 because - Numpad 1 = -Numpad 0 -1 where -1 is to account for the user input being shifted by 1

                if (user_choice < _regionTable.Count && user_choice >= 0 && _regionTable[user_choice] != null) //Dereferencing one of the invalid array cells automatically crashes
                {
                    _regionTable[user_choice].Enter(GetPlayer());
                }

                else if(user_choice == _regionTable.Count)
                {
                    _gameContext.GetEventManager().TriggerEvent(new Events.QuitGameEvent());
                }
            }
        }
    }
}

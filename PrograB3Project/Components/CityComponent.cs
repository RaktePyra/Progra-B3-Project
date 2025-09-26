using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    internal class CityComponent : LocationComponent
    {
        private List<KeyLocationComponent> _locationTable = new List<KeyLocationComponent>();
        public CityComponent(GameObject owner, Context game_context) : base(owner, game_context)
        {

        }

        public override void Enter(GameObject player)
        {
            base.Enter(player);
           
            Console.Clear();
            Console.WriteLine("Welcome to " + GetOwnerGameObject().GetName() + " City.");
            Console.WriteLine("Where do you wanna go?");

            for (int location_index = 0; location_index < _locationTable.Count; location_index++)
            {
                Console.WriteLine(location_index + ". " + _locationTable[location_index].GetOwnerGameObject().GetName());
            }
            Console.WriteLine(_locationTable.Count + 1 + ". Go back to " + _parentLocation.GetOwnerGameObject().GetName());
        }

        public override void ProcessInput(ConsoleKeyInfo key)
        {
           int user_choice = (int) key.Key - (int)ConsoleKey.NumPad1;

            if (user_choice >= 0 && user_choice < _locationTable.Count)
            {
                _locationTable[user_choice].Enter(GetPlayer());
            }
            else if (user_choice == _locationTable.Count)
            {
                Console.Clear();
                _parentLocation.Enter(GetPlayer());
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    internal class CityComponent : LocationComponent
    {
        private List<LocationComponent> _locationTable = new List<LocationComponent>();
        public CityComponent(GameObject owner) : base(owner)
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
        }
    }
}

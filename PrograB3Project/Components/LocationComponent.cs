using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class LocationComponent : Component
    {
        public LocationComponent(GameObject owner) : base(owner)
        {
        }

        public virtual void Enter()
        {
            Console.WriteLine("You entered a Location Component");
        }

        public virtual void AddLocation(LocationComponent location)
        {

        }
    }
}

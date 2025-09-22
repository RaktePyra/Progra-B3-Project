using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class LocationComponent
    {
        private string _name;

        public virtual void Enter()
        {
            Console.WriteLine("You entered a Location Component");
        }

        public LocationComponent(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
        public virtual void AddLocation(LocationComponent location)
        {

        }
    }
}

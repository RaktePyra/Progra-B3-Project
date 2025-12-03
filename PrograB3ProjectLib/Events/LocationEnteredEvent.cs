using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Events
{
    public class LocationEnteredEvent : Event
    {
        public readonly string _locationId;
        public readonly List<string> _childLocationsID;
    }
}

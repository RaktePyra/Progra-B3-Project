using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Events
{
    internal class LocationCreatedEvent
    {
        public readonly string LocationID;
        public readonly string LocationName;
        public readonly Vector2 Location;
        public LocationCreatedEvent()
        { 

        }
    }
}

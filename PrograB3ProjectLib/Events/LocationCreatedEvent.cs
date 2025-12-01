using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Events
{
    internal class LocationCreatedEvent : Event
    {
        public readonly string LocationID;
        public readonly string LocationName;
        public readonly Vector2 LocationPosition;
        public LocationCreatedEvent(string id,string name, Vector2 position)
        { 
            LocationID = id;
            LocationName = name;
            LocationPosition = position;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Events
{
    internal class PlayerCreatedEvent : Event
    {
        public readonly Vector2 _position;
        public readonly string _name;
        public readonly string _id;
        public PlayerCreatedEvent(string id, string name, Vector2 position) 
        { 
            _id = id;
            _name = name;
            _position = position;
        }
    }
}

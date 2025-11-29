using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Events
{
    public class InputEvent : Event
    {
        private ConsoleKeyInfo _pressedKey;

        public InputEvent(ConsoleKeyInfo input_key) 
        {
            _pressedKey = input_key;
        }

        public ConsoleKeyInfo GetKeyInfo()
        {
            return _pressedKey;
        }
    }
}

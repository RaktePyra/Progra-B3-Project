using PrograB3Project.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project
{
    public class Context
    {
        private GameEngine _engine;
        private EventManager _eventManager;


        public Context(GameEngine engine, EventManager event_manager)
        {
            _engine = engine;
            _eventManager = event_manager;
        }

        public GameEngine GetGameEngine()
        {
            return _engine;
        }

        public EventManager GetEventManager()
        {
            return _eventManager;
        }
    }
}

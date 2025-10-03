using PrograB3Project.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrograB3Project.Interfaces
{
    public interface IGameEngine
    {
        public void Run();

        public void RegisterGameObject(GameObject game_object);

        public void UnregisterGameObject(GameObject game_object);

        public void OnQuitGame(Event quit_game_event);
    }
}

using PrograB3Project.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    internal class CharacterComponent : Component
    {
        private int _bargainingStat = 10;

        public CharacterComponent(GameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager) : base(owner, engine, event_manager)
        {
        }

        public void IncreaseBargainingStat(int number_to_increase_stat)
        {
            _bargainingStat += number_to_increase_stat;
        }

        public int GetBargainingStat()
        {
            return _bargainingStat;
        }
    }
}

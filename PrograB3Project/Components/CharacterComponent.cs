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
        private string _name;

        public CharacterComponent(GameObject owner, GameEngine engine, EventManager event_manager) : base(owner, engine, event_manager)
        {
            _name = owner.GetName();
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

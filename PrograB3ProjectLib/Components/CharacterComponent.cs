using PrograB3Project.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrograB3Project.Interfaces;

namespace PrograB3Project.Components
{
    internal class CharacterComponent : Component, ISavableComponent
    {
        private int _bargainingStat = 10;
        private string _id;
        public CharacterComponent(GameObject owner) : base(owner)
        {
            _id = owner.GetName()+"_CharacterComponent";
        }

        public void IncreaseBargainingStat(int number_to_increase_stat)
        {
            _bargainingStat += number_to_increase_stat;
        }

        public int GetBargainingStat()
        {
            return _bargainingStat;
        }

        public string Save()
        {
            return _bargainingStat.ToString();
        }

        public void RestoreDataFromFile(string data)
        {
          int.TryParse(data, out _bargainingStat);
        }

        public string GetID()
        {
            return _id;
        }
    }
}

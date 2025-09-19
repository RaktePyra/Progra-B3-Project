using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project
{
    internal class Region : Components.IRegion
    {
        private List<City> _cityTable=new List<City>();
        private const int MAX_CITY_RANDOM_NUMBER = 3;
        public Region() 
        {
            for (int i = 0; i < MAX_CITY_RANDOM_NUMBER; i++)
            {
                _cityTable.Add(new City());
            }
        }

        public void Enter()
        {
            throw new NotImplementedException();
        }
    }
}

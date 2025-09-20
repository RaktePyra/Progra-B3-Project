using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project
{
    internal class Region : IRegion
    {
        private List<ICity> _cityTable = new List<ICity>();
        private const int MAX_CITY_RANDOM_NUMBER = 3;
        public Region() 
        {
            for (int i = 0; i < MAX_CITY_RANDOM_NUMBER; i++)
            {
                _cityTable.Add(new City());
            }
        }
        public Region(Type city_type_to_create)
        {
            if(city_type_to_create is ICity)
            {
                Random rand = new Random();
                int region_count = rand.Next(1, MAX_CITY_RANDOM_NUMBER+1);
                for (int i = 0; i < region_count; i++)
                {
                    _cityTable.Add((ICity)Activator.CreateInstance(city_type_to_create));
                }
            }
            else
            {
                throw new Exception("Invalid city type provided");
            }
        }

        public void Enter()
        {
           
        }
    }
}

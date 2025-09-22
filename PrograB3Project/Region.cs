using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project
{
    internal class Region : IRegion
    {
        private List<IKeyLocation> _cityTable = new List<IKeyLocation>();
        private const int MAX_CITY_RANDOM_NUMBER = 3;

        public Region() 
        {
            for (int city_index = 0; city_index < MAX_CITY_RANDOM_NUMBER; city_index++)
            {
                _cityTable.Add(new City());
            }
        }

        public Region(Type city_type_to_create)
        {
            if(city_type_to_create is IKeyLocation)
            {
                Random rand = new Random();
                int region_count = rand.Next(1, MAX_CITY_RANDOM_NUMBER+1);
                for (int city_index = 0; city_index < region_count; city_index++)
                {
                    _cityTable.Add((IKeyLocation)Activator.CreateInstance(city_type_to_create));
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

        public void EnterLocation(int location_index)
        {
            if(0 <= location_index && location_index < _cityTable.Count())
            {
                _cityTable[location_index].Enter();
            }
        }
    }
}

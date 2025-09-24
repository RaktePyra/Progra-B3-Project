using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    internal class RegionComponent : LocationComponent
    {
        private List<LocationComponent> _cityTable = new List<LocationComponent>();
        private const int MAX_CITY_RANDOM_NUMBER = 3;

        public RegionComponent(GameObject owner) : base(owner) 
        {

        }

        
        //public RegionComponent(Type city_type_to_create, GameObject owner) : base(owner)
        //{
        //    if(city_type_to_create is LocationComponent)
        //    {
        //        Random rand = new Random();
        //        int region_count = rand.Next(1, MAX_CITY_RANDOM_NUMBER+1);
        //        for (int city_index = 0; city_index < region_count; city_index++)
        //        {
        //            _cityTable.Add((LocationComponent)Activator.CreateInstance(city_type_to_create));
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("Invalid city type provided");
        //    }
        //}

        public override void Enter(GameObject player) 
        {
           base.Enter(player);
        }

        public void EnterLocation(int location_index)
        {
            if(0 <= location_index && location_index < _cityTable.Count())
            {
                _cityTable[location_index].Enter(GetPlayer());
            }
        }

        public override void AddLocation(LocationComponent location)
        {
            base.AddLocation(location);
            if (!_cityTable.Contains(location))
            {
                _cityTable.Add(location);
            }
        }
    }
}

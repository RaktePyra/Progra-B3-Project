using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project
{
    internal class World
    {
        private List<Region> _regionTable=new List<Region>();
        private const int MAX_REGION_RANDOM_NUMBER = 3;
        //Idea : Create a vector class that can be used as a parameter to this World to specify inside the vector
        //how many cities would be in a region and using the size of the vector as the number of regions inside the world
        public World(int desired_regions_number)
        {
            for (int i = 0; i < desired_regions_number; i++)
            {
                _regionTable = new List<Region>();
            }
        }  
        public World()
        {
            Random random = new Random();
            int random_regions_number=random.Next()% MAX_REGION_RANDOM_NUMBER;
            for (int i = 0; i < random_regions_number; i++)
            {
                _regionTable = new List<Region>();
            }
        }
    }
}

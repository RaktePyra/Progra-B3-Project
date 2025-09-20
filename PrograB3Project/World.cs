using PrograB3Project.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project
{
    public class World 
    {
        private List<Components.IRegion> _iRegionTable = new List<Components.IRegion>();
        private const int MAX_REGION_RANDOM_NUMBER = 3;
        //Idea : Create a vector class that can be used as a parameter to this World to specify inside the vector
        //how many cities would be in a region and using the size of the vector as the number of regions inside the world
        public World(int desired_regions_number)
        {
            for (int i = 0; i < desired_regions_number; i++)
            {
                _iRegionTable.Add(new Region());
            }
        }
        //OOOF, Black Magic incoming to apply Dependy inversion Principle, private till it hasn't been tested thoroughly
        //Ressources : https://stackoverflow.com/questions/56134343/c-sharp-create-an-instance-of-a-class-from-a-type-fullname
        //             https://learn.microsoft.com/fr-fr/dotnet/api/system.activator.createinstance?view=net-8.0
        public World(Type region_type_to_create)
        {
            Random random = new Random();
            int random_regions_number = Math.Clamp(random.Next(),1, MAX_REGION_RANDOM_NUMBER);

            for (int i = 0; i < random_regions_number; i++)
            {
                _iRegionTable.Add((IRegion)Activator.CreateInstance(region_type_to_create));
            }
        }
        public void EnterRegion(int region_index)
        {
            if(_iRegionTable.ElementAt(region_index)!=null)
            {
                _iRegionTable.ElementAt(region_index).Enter();
            }
        }
    }
}

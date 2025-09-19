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
        
        private List<Region> _regionTable = new List<Region>();
        private List<Components.IRegion> _IregionTable = new List<Components.IRegion>();
        private const int MAX_REGION_RANDOM_NUMBER = 3;
        //Idea : Create a vector class that can be used as a parameter to this World to specify inside the vector
        //how many cities would be in a region and using the size of the vector as the number of regions inside the world
        public World(int desired_regions_number)
        {
            for (int i = 0; i < desired_regions_number; i++)
            {
                _regionTable.Add(new Region());
            }
        }
        //OOOF, Black Magic incoming to apply Dependy inversion Principle, private till it hasn't been tested thoroughly
        //Ressources : https://stackoverflow.com/questions/56134343/c-sharp-create-an-instance-of-a-class-from-a-type-fullname
        //             https://learn.microsoft.com/fr-fr/dotnet/api/system.activator.createinstance?view=net-8.0
        public World(IRegion region_type_to_create)
        {
            Random random = new Random();
            int random_regions_number = random.Next() % MAX_REGION_RANDOM_NUMBER;
            Type type = region_type_to_create.GetType();
            for (int i = 0; i < random_regions_number; i++)
            {
                _IregionTable.Add((IRegion)Activator.CreateInstance(type));
            }
        }
        public void EnterRegion(IRegion region_to_enter)
        {
            foreach (IRegion region in _IregionTable)
            {
                if(region.GetType()==region_to_enter.GetType())
                {
                    region.Enter();
                }
            }
        }
    }
}

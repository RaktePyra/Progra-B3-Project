using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class WorldComponent : LocationComponent
    {
        private List<LocationComponent> _regionTable = new List<LocationComponent>();
        private const int MAX_REGION_RANDOM_NUMBER = 3;
        //Idea : Create a vector class that can be used as a parameter to this World to specify inside the vector
        //how many cities would be in a region and using the size of the vector as the number of regions inside the world

        public WorldComponent(GameObject owner) : base(owner)
        { 
        }

        //public WorldComponent(int desired_regions_number, GameObject owner) : base(owner)
        //{
        //    for (int region_index = 0; region_index < desired_regions_number; region_index++)
        //    {
        //        _regionTable.Add(new RegionComponent());
        //    }
        //}
        //1.0:OOOF, Black Magic incoming to apply Dependy inversion Principle, private till it hasn't been tested thoroughly
        ////1.1: Testing succeeded but needs for research on Activator Class and absolute Type Checking before Creating the instance
        //Ressources : https://stackoverflow.com/questions/56134343/c-sharp-create-an-instance-of-a-class-from-a-type-fullname
        //             https://learn.microsoft.com/fr-fr/dotnet/api/system.activator.createinstance?view=net-8.0
        
        //public WorldComponent(Type region_type_to_create,GameObject owner) : base(owner) 
        //{
        //    Random random = new Random();
        //    int random_regions_number = Math.Clamp(random.Next(),1, MAX_REGION_RANDOM_NUMBER);

        //    for (int region_index = 0; region_index < random_regions_number; region_index++)
        //    {
        //        //TO DO : Type Check to see if region_type_to_create possess the IRegion interface
        //        _regionTable.Add((LocationComponent)Activator.CreateInstance(region_type_to_create));
        //    }
            
        //}

        public void EnterRegion(int region_index)
        {
            if(_regionTable.ElementAt(region_index) != null)
            {
                _regionTable.ElementAt(region_index).Enter(GetPlayer());
            }
        }

        
        public override void Enter(GameObject player)
        {
            base.Enter(player);
            Console.WriteLine("Welcome to " + GetOwnerGameObject().GetName());
            Console.WriteLine("Where do you want to go");

            for( int region_index = 0; region_index < _regionTable.Count; region_index ++ )
            {
                Console.WriteLine((region_index + 1) + "." + _regionTable[region_index].GetOwnerGameObject().GetName());
            }
        }

        public override void AddLocation(LocationComponent location)
        {
            base.AddLocation(location);
           if(!_regionTable.Contains(location))
            {
                _regionTable.Add(location);
            }
           else
            {
                throw new Exception("location already inside world");
            }
        }

        public override void ProcessInput(ConsoleKeyInfo key)
        {
            if (key.Key >= ConsoleKey.NumPad1 && key.Key <= ConsoleKey.NumPad9)
            {
                int user_choice = (int)key.Key - (int)ConsoleKey.NumPad1;

                if (user_choice < _regionTable.Count && user_choice >= 0 && _regionTable[user_choice] != null) //Dereferencing one of the invalid array cells automatically crashes
                {
                    _regionTable[user_choice].Enter(GetPlayer());
                }

            }
        }
    }
}

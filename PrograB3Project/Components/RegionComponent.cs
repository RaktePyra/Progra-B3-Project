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

        public RegionComponent(GameObject owner,Context game_context) : base(owner, game_context) 
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
            Console.Clear();
            Console.WriteLine("Welcome to " + GetOwnerGameObject().GetName() + " Region.");
            Console.WriteLine("Where do you wanna go?");

            for (int city_index = 0; city_index < _cityTable.Count; city_index++)
            {
                Console.WriteLine(city_index +1 + "." + _cityTable[city_index].GetOwnerGameObject().GetName());
            }
            Console.WriteLine(_cityTable.Count + 1 + ".Quit to " + _parentLocation.GetOwnerGameObject().GetName());
        }

        public void EnterLocation(int location_index) //Obsolete
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

        public override void ProcessInput(ConsoleKeyInfo key)
        {
            if (key.Key >= ConsoleKey.NumPad1 && key.Key <= ConsoleKey.NumPad9)
            {
                int user_choice = (int)key.Key - (int)ConsoleKey.NumPad1;

                if (user_choice < _cityTable.Count && user_choice >= 0 && _cityTable[user_choice] != null) //Dereferencing one of the invalid array cells automatically crashes
                {
                    _cityTable[user_choice].Enter(GetPlayer());
                }

                else if (user_choice==_cityTable.Count)
                {
                    Console.Clear();
                    _parentLocation.Enter(GetPlayer());
                }

            }
        }
    }
}

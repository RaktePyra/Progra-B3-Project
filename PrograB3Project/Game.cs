using PrograB3Project.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Disables the code suggestion to remove the type after the "new" Operator
#pragma warning disable IDE0090
namespace PrograB3Project
{
    internal class Game
    {
        private GameEngine _engine;
        public Game(GameEngine engine)
        {
            _engine = engine;
        }

        public void Run()
        {
            GameObject world = new GameObject("World");
            WorldComponent world_component = new WorldComponent(world);

            GameObject region_a = new GameObject("region a");
            RegionComponent region_a_comp = new RegionComponent(region_a);
            GameObject city_a = new GameObject("city a");
            CityComponent city_a_comp=new CityComponent(city_a);
            GameObject city_b = new GameObject("city b");
            CityComponent city_b_comp = new CityComponent(city_b);

            GameObject region_b = new GameObject("region_b");
            RegionComponent region_b_comp = new RegionComponent(region_b);
            GameObject city_c = new GameObject("city c");
            CityComponent city_c_comp = new CityComponent(city_c);
            GameObject city_d = new GameObject("city d");
            CityComponent city_d_comp = new CityComponent(city_d);

            region_a_comp.AddLocation(city_a_comp);
            region_a_comp.AddLocation(city_b_comp);

            region_b_comp.AddLocation(city_c_comp);
            region_b_comp.AddLocation (city_d_comp);

            world_component.AddLocation(region_a_comp);
            world_component.AddLocation (region_b_comp);


           


        }

        public void OnExit()
        {

        }   
    }
}

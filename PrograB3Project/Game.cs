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
        private Context _context;

        public Game(Context game_context)
        {   
            _context = game_context;
            _engine = game_context.GetGameEngine();
            
        }

        public void Run()
        {
            GameObject world = new GameObject("World", _context);
            WorldComponent world_component = new WorldComponent(world,_context);

            GameObject region_a = new GameObject("region a", _context);
            RegionComponent region_a_comp = new RegionComponent(region_a, _context);
            GameObject city_a = new GameObject("city a", _context);
            CityComponent city_a_comp=new CityComponent(city_a, _context);
            GameObject city_b = new GameObject("city b", _context);
            CityComponent city_b_comp = new CityComponent(city_b, _context);

            GameObject region_b = new GameObject("region_b", _context);
            RegionComponent region_b_comp = new RegionComponent(region_b, _context);
            GameObject city_c = new GameObject("city c", _context);
            CityComponent city_c_comp = new CityComponent(city_c, _context);
            GameObject city_d = new GameObject("city d", _context);
            CityComponent city_d_comp = new CityComponent(city_d, _context);

            region_a_comp.AddLocation(city_a_comp);
            region_a_comp.AddLocation(city_b_comp);

            region_b_comp.AddLocation(city_c_comp);
            region_b_comp.AddLocation (city_d_comp);

            world_component.AddLocation(region_a_comp);
            world_component.AddLocation (region_b_comp);

            GameObject player = new GameObject("player", _context);
            player.AddComponent(new InputComponent(player, _context));
            _engine.SetPlayer(player);
            world_component.Enter(player);
        }

        public void OnExit()
        {

        }   
    }
}

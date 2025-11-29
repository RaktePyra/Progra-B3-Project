
using PrograB3Project.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    internal class RegionComponent : LocationComponent
    {
        public RegionComponent(Interfaces.IGameObject owner, Interfaces.IEventManager event_manager, int level_size_x, int level_size_y, CollisionManager collision_manager, CollisionComponent collision_component, string id) : base(owner, event_manager, level_size_x, level_size_y, collision_manager, collision_component,id) 
        {

        }
    }
}

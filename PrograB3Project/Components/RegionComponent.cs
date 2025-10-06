using PrograB3Project.Components.Rendering;
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
        public RegionComponent(Interfaces.IGameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager, RenderManager render_manager, int level_size_x, int level_size_y, CollisionManager collision_manager, CollisionComponent collision_component) : base(owner, engine, event_manager, render_manager, level_size_x, level_size_y, collision_manager, collision_component) 
        {

        }

        public override void OnCollisionEnter(CollisionComponent collider)
        {
            Enter(collider.GetOwnerGameObject());
        }
    }
}

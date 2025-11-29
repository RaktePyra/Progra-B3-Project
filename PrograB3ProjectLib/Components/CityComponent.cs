using PrograB3Project.Interfaces;
using System.Collections.Generic;
namespace PrograB3Project.Components
{
    internal class CityComponent : LocationComponent
    {
        private List<KeyLocationComponent> _locationTable = new List<KeyLocationComponent>();

        public CityComponent(Interfaces.IGameObject owner, Interfaces.IEventManager event_manager, int level_size_x, int level_size_y, CollisionManager collision_manager, CollisionComponent collision_component, string id) : base(owner, event_manager, level_size_x, level_size_y, collision_manager, collision_component,id)
        {
        }

        public void AddLocation(KeyLocationComponent location)
        {
            if (!_locationTable.Contains(location))
            {
                _locationTable.Add(location);
            }
        }

        public override void Enter(IGameObject player)
        {
            base.Enter(player);
            foreach(KeyLocationComponent location in _locationTable)
            {
                location.OnParentLocationEntered();
            }
        }
    }
}

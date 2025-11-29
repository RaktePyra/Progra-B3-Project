using PrograB3Project.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project
{
    public class CollisionManager
    {
        private List<CollisionComponent> _collisionComponentTable = new List<CollisionComponent>();


        public CollisionComponent GetCollisionComponentAtLocation(LocationCoordinates location)
        {
            CollisionComponent component_to_return = null;

            foreach(CollisionComponent component in _collisionComponentTable)
            {
                if(component.GetTransform()._xCoordinate == location._xCoordinate && component.GetTransform()._yCoordinate == location._yCoordinate)
                {
                    component_to_return = component;
                    break;
                }
            }

            return component_to_return;
        }

        public void RegisterCollisionComponent(CollisionComponent collision_component)
        {
            if(!_collisionComponentTable.Contains(collision_component))
            {
                _collisionComponentTable.Add(collision_component);
            }
        }

        public void UnregisterCollisionComponent(CollisionComponent collision_component)
        {
            if (_collisionComponentTable.Contains(collision_component))
            {
                _collisionComponentTable.Remove(collision_component);
            }
        }
    }
}

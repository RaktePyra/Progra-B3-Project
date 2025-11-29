using PrograB3Project.Components;
using System.Collections.Generic;
namespace PrograB3Project.Events
{
    public class CollisionEvent : Event
    {
        private List<CollisionComponent> _collidingComponentsTable = new List<CollisionComponent>();
        public CollisionEvent(CollisionComponent collider1, CollisionComponent collider2)
        {
            _collidingComponentsTable.Add(collider1);
            _collidingComponentsTable.Add(collider2);
        }

        public bool IsPartOfCollision(CollisionComponent collider)
        {
            bool is_part_of_collision = false;
            is_part_of_collision = _collidingComponentsTable.Contains(collider);
            return is_part_of_collision;
        }

        public CollisionComponent GetOtherCollisionComponent(CollisionComponent collider)
        {
            CollisionComponent comp_to_return = null;
            if (IsPartOfCollision(collider))
            {
                List<CollisionComponent> tempList = new List<CollisionComponent>();
                foreach (CollisionComponent collider_comp in _collidingComponentsTable)
                {
                    tempList.Add(collider_comp);
                }
                tempList.Remove(collider);
                comp_to_return = tempList[0];
            }
            return comp_to_return;
        }
    }
}

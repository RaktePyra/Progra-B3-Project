using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    public class TransformComponent : Component
    {
        private LocationCoordinates _position = new LocationCoordinates();
        public TransformComponent(IGameObject owner, IGameEngine engine, IEventManager event_manager, RenderManager render_manager) : base(owner, engine, event_manager, render_manager)
        {
        }

        public void SetPosition(int x_pos, int y_pos)
        {
            _position = new LocationCoordinates(x_pos,y_pos);
        }

        public LocationCoordinates GetLocationCoordinates()
        {
            return _position;
        }
    }

    public struct LocationCoordinates
    {
        public LocationCoordinates(int x_coord,int y_coord)
        {
            _xCoordinate = x_coord;
            _yCoordinate = y_coord;
        }

        public readonly int _xCoordinate;
        public readonly int _yCoordinate;
    }
}

using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    internal class MovementComponent : Component
    {
        private TransformComponent _playerTransform;

        public MovementComponent(IGameObject owner, IGameEngine engine, IEventManager event_manager, RenderManager render_manager,TransformComponent player_transform) : base(owner, engine, event_manager, render_manager)
        {
            _playerTransform = player_transform;
        }


        public override void ProcessInput(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.Z:
                    {
                        MoveY(-1);
                        break;
                    }
                case ConsoleKey.S:
                    {
                        MoveY(1);
                        break;
                    }
                case ConsoleKey.Q:
                    {
                        MoveX(-1);
                        break;
                    }
                case ConsoleKey.D:
                    {
                        MoveX(1);
                        break;
                    }
            }
        }
        private void MoveX(int move_value)
        {
            LocationCoordinates player_coord = _playerTransform.GetLocationCoordinates();
            _playerTransform.SetPosition(player_coord._xCoordinate + move_value, player_coord._yCoordinate);
        }

        private void MoveY(int move_value)
        {
            LocationCoordinates player_coord = _playerTransform.GetLocationCoordinates();
            _playerTransform.SetPosition(player_coord._xCoordinate, player_coord._yCoordinate + move_value);
        }
    }
}

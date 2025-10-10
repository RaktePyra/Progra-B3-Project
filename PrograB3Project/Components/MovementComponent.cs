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
        private CollisionComponent _collisionComponent;

        public MovementComponent(IGameObject owner,TransformComponent player_transform) : base(owner)
        {
            _playerTransform = player_transform;
            _collisionComponent = owner.GetComponent<CollisionComponent>();
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
            if (_collisionComponent != null && _collisionComponent.CanMove(new LocationCoordinates(_playerTransform.GetLocationCoordinates()._xCoordinate + move_value, (_playerTransform.GetLocationCoordinates()._yCoordinate))))
            {
                _playerTransform.SetPosition(player_coord._xCoordinate + move_value, player_coord._yCoordinate);
            }

            else if(_collisionComponent == null)
            {
                _playerTransform.SetPosition(player_coord._xCoordinate + move_value, player_coord._yCoordinate);
            }
            
        }

        private void MoveY(int move_value)
        {
            LocationCoordinates player_coord = _playerTransform.GetLocationCoordinates();
            if (_collisionComponent != null && _collisionComponent.CanMove(new LocationCoordinates(_playerTransform.GetLocationCoordinates()._xCoordinate , (_playerTransform.GetLocationCoordinates()._yCoordinate + move_value))))
            {
                _playerTransform.SetPosition(player_coord._xCoordinate, player_coord._yCoordinate + move_value);
            }

            else if (_collisionComponent == null) 
            {
                _playerTransform.SetPosition(player_coord._xCoordinate, player_coord._yCoordinate + move_value);
            }
        }
    }
}

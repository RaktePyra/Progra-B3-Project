using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Components
{
    internal class JobComponent : KeyLocationComponent
    {
        private InventoryComponent _playerInventoryComponent;
        private Random _randomGenerator = new Random();
        private Interfaces.IGameObject _playerGameObject;

        public JobComponent(Interfaces.IGameObject owner, Interfaces.IEventManager event_manager, LocationComponent parentLocation, CollisionComponent collision_component, TransformComponent owner_transform) : base(owner, event_manager, parentLocation,collision_component,owner_transform)
        {
        }


        public override void Enter(Interfaces.IGameObject player)
        {
            base.Enter(player);
            _playerGameObject = player;
            _playerInventoryComponent = player.GetComponent<InventoryComponent>();
        }

        public override void ProcessInput(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.E:
                    {
                        _playerInventoryComponent.AddMoney(69);
                        //Console.WriteLine("Committing to the grind grants you the power to generate " + _randomGenerator.Next() % 100 + " money");
                        //Console.WriteLine("Your gold : " + _playerInventoryComponent.GetMoney());
                        break;
                    }
                case ConsoleKey.NumPad0:
                    {

                        Exit(_playerGameObject);
                        break;
                    }
            }
        }
    }
}

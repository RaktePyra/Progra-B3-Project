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

        public JobComponent(Interfaces.IGameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager, LocationComponent parentLocation) : base(owner, engine,event_manager, parentLocation)
        {

        }


        public override void Enter(Interfaces.IGameObject player)
        {
            base.Enter(player);
            Console.Clear();
            _playerGameObject = player;
            _playerInventoryComponent = player.GetComponent<InventoryComponent>();
            Console.WriteLine("You entered the Grind Shrine");
            Console.WriteLine("Press [E] to commit to the grind");
            Console.WriteLine("Press [0] to go back to the city");
        }

        public override void ProcessInput(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.E:
                    {
                        _playerInventoryComponent.AddMoney(69);
                        Console.WriteLine("Committing to the grind grants you the power to generate " + _randomGenerator.Next() % 100 + " money");
                        Console.WriteLine("Your gold : " + _playerInventoryComponent.GetMoney());
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

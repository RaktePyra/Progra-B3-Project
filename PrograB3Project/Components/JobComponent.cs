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
        private GameObject _playerGameObject;

        public JobComponent(GameObject owner, Context game_context, LocationComponent parentLocation) : base(owner, game_context, parentLocation)
        {

        }

        public override void Enter(GameObject player)
        {
            _playerGameObject = player;
            _playerInventoryComponent = player.GetComponent<InventoryComponent>();
            Console.WriteLine("You entered the Grind Shrine");
            Console.WriteLine("Press [E] to commit to the grind");
        }

        public override void ProcessInput(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.E:
                    {
                        _playerInventoryComponent.AddMoney(69);
                        Console.WriteLine("Committing to the grind grants you the power to generate " + _randomGenerator.Next()%100 +" money");
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

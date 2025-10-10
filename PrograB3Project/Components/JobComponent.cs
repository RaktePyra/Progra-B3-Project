using PrograB3Project.Components.Rendering;
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
        private JobRenderComponent _renderComponent;
        private Interfaces.IGameObject _playerGameObject;

        public JobComponent(Interfaces.IGameObject owner, Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager, LocationComponent parentLocation, RenderManager render_manager,CollisionComponent collision_component, TransformComponent owner_transform,JobRenderComponent job_render_comp) : base(owner, engine, event_manager, parentLocation, render_manager,collision_component,owner_transform)
        {
            _renderComponent = new JobRenderComponent(owner, _gameEngine, _eventManager,"", render_manager);
            _renderComponent = job_render_comp;
        }


        public override void Enter(Interfaces.IGameObject player)
        {
            base.Enter(player);
            _playerGameObject = player;
            _playerInventoryComponent = player.GetComponent<InventoryComponent>();
            _renderManager.RegisterRenderComponent(_renderComponent);
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
                        _renderManager.UnregisterRenderComponent(_renderComponent);
                        Exit(_playerGameObject);
                        break;
                    }
            }
        }
    }
}

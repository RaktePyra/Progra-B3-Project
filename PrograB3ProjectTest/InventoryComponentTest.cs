using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrograB3Project;
using PrograB3Project.Components;
using PrograB3Project.Events;
using PrograB3Project.Interfaces;
namespace PrograB3ProjectTest
{

        public class InventoryTests
        {
            private InventoryComponent _inventoryToTest;
            [SetUp]
            public void Setup()
            {
            IGameEngine game_engine = new GameEngine();
            EventManager event_manager = new EventManager();
            _inventoryToTest = new InventoryComponent(new PrograB3Project.GameObject("testObject", game_engine, event_manager),game_engine, event_manager);
            }

            [Test]
            public void AddItemTest()
            {

            }
        }
}

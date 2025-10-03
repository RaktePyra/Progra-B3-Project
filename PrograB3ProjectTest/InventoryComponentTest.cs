using PrograB3Project;
using PrograB3Project.Components;
using PrograB3Project.Events;
using PrograB3Project.Interfaces;
namespace PrograB3ProjectTest
{

    public class InventoryTests
    {
        private InventoryComponent _inventoryToTest;
        private IGameEngine game_engine = new GameEngine();
        private IEventManager event_manager = new EventManager();
        private IGameObject item;

        [SetUp]

        public void Setup()
        {
            item = new GameObject("item", game_engine, event_manager);
            _inventoryToTest = new InventoryComponent(new GameObject("testObject", game_engine, event_manager), game_engine, event_manager);
        }

        [Test]

        public void GetItemCountTest()
        {
            _inventoryToTest.AddItem(new ItemComponent(item, game_engine, event_manager, "apple", 10, 50));

            Assert.That(_inventoryToTest.GetNumberOfItems(), Is.EqualTo(1));
            _inventoryToTest.AddItem(new ItemComponent(item, game_engine, event_manager, "bread", 10, 50));
            _inventoryToTest.AddItem(new ItemComponent(item, game_engine, event_manager, "water", 10, 50));
            Assert.That(_inventoryToTest.GetNumberOfItems(), Is.EqualTo(3));

        }
        [Test]

        public void RemoveItemTest()
        {

            _inventoryToTest.AddItem(new ItemComponent(item, game_engine, event_manager, "apple", 10, 50));

            Assert.That(_inventoryToTest.GetNumberOfItems(), Is.EqualTo(1));
            _inventoryToTest.AddItem(new ItemComponent(item, game_engine, event_manager, "bread", 10, 50));
            _inventoryToTest.AddItem(new ItemComponent(item, game_engine, event_manager, "water", 10, 50));
            Assert.That(_inventoryToTest.GetNumberOfItems(), Is.EqualTo(3));
            _inventoryToTest.RemoveItem(_inventoryToTest.GetItem(0));
            Assert.That(_inventoryToTest.GetNumberOfItems(), Is.EqualTo(2));
        }
        [Test]
        public void GetItemByIndexTest()
        {
            ItemComponent apple = new ItemComponent(item, game_engine, event_manager, "apple", 10, 50);
            ItemComponent bread = new ItemComponent(item, game_engine, event_manager, "bread", 10, 50);
            ItemComponent water = new ItemComponent(item, game_engine, event_manager, "water", 10, 50);
            _inventoryToTest.AddItem(apple);
            _inventoryToTest.AddItem(bread);
            _inventoryToTest.AddItem(water);

            Assert.That(_inventoryToTest.GetItem(0).Equals(apple));
            Assert.That(!_inventoryToTest.GetItem(0).Equals(bread));
            Assert.That(_inventoryToTest.GetItem(3) == null);

        }
    }
}

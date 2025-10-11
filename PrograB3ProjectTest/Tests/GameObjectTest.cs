using PrograB3Project;
using PrograB3Project.Components;
using PrograB3Project.Events;
using PrograB3ProjectTest.TestData;

namespace PrograB3ProjectTest.Tests.Tests
{
    internal class GameObjectTest
    {
        private GameObject _objectToTest;
        private EventManager _eventManager = new EventManager();
        [SetUp]
        public void SetUp()
        {
            _objectToTest = new GameObject("test object", _eventManager);
        }

        [Test]
        public void AddingComponentTest()
        {
            Assert.That(_objectToTest, Is.Not.Null);
            Assert.That(_objectToTest.GetComponentCount(), Is.EqualTo(0));
            _objectToTest.AddComponent(new MockSavableComponent("mock", _eventManager));
            Assert.That(_objectToTest.GetComponentCount(), Is.EqualTo(1));
        }

        [Test]

        public void GettingComponentTest()
        {
            MockSavableComponent mock = new MockSavableComponent("mock", _eventManager);
            _objectToTest.AddComponent(mock);
            Assert.That(_objectToTest.GetComponent<MockSavableComponent>(), Is.EqualTo(mock));
            Assert.That(_objectToTest.GetComponent<InventoryComponent>(), Is.Null);
        }
    }
}

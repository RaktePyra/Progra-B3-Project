using PrograB3Project;
using PrograB3Project.Events;

namespace PrograB3ProjectTest.TestData
{
    internal class SavingTest
    {
        private SaveManager _saveManager;
        private EventManager event_manager = new EventManager();
        private List<MockSavableComponent> mock_savable_component_table = new List<MockSavableComponent>();
        [SetUp]

        public void Setup()
        {
            GameObject mock = new GameObject("mock", event_manager);
            _saveManager = new SaveManager(event_manager, "../../../TestData/Save.sav");
            for (int mock_index = 0; mock_index < 10; mock_index++)
            {
                MockSavableComponent mock_comp = new MockSavableComponent();
                mock_savable_component_table.Add(mock_comp);
                mock.AddComponent(mock_comp);
            }
            
        }

        [Test]

        public void SavingToFileTest()
        {
            Assert.Pass();
        }
    }
}

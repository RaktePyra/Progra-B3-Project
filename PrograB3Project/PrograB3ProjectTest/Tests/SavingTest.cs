using PrograB3Project;
using PrograB3Project.Events;
using PrograB3ProjectTest.Events;
using PrograB3ProjectTest.TestData;

namespace PrograB3ProjectTest.Tests
{
    internal class SavingTest
    {
        private SaveManager _saveManager;
        private EventManager event_manager = new EventManager();
        private List<MockSavableComponent> mock_savable_component_table = new List<MockSavableComponent>();
        private int _savedItemCount;
        private int _numberOfItemToSave = 10;
        [SetUp]

        public void Setup()
        {
            event_manager.RegisterEvent<MockEvent>(OnObjectDataCorrectlyRestored);
            _savedItemCount = 0;
            GameObject mock = new GameObject("mock", event_manager);
            _saveManager = new SaveManager(event_manager, "../../../TestData/Save.sav");
            for (int mock_index = 0; mock_index < _numberOfItemToSave; mock_index++)
            {
                MockSavableComponent mock_comp = new MockSavableComponent("mock_" + mock_index, event_manager);
                mock_savable_component_table.Add(mock_comp);
                mock.AddComponent(mock_comp);
            }
            
        }

        [Test]

        public void SavingToFileTest()
        {
            _saveManager.Save();
            _saveManager.LoadSaveFile();
            Assert.That(_savedItemCount, Is.EqualTo(_numberOfItemToSave));
        }

        public void OnObjectDataCorrectlyRestored(Event abstract_event )
        {
            _savedItemCount++;
        }
    }
}

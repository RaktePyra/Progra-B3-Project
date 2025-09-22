using PrograB3Project;
using PrograB3Project.Components;
using PrograB3ProjectTest.Exploration_System_Tests;

namespace PrograB3ProjectTest
{
    public class Tests
    {
        private GameObject _world;
        [SetUp]
        public void Setup()
        {
            _world = new GameObject();
            WorldComponent world_component = new WorldComponent("Tamriel");
        }

        [Test]
        public void AddLocationTest()
        {
           
        }
    }
}
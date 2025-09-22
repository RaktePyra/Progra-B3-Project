using PrograB3Project;
using PrograB3ProjectTest.Exploration_System_Tests;

namespace PrograB3ProjectTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void DependancyInversionTest()
        {
            
            MockRegion mock_region = new MockRegion();
            WorldComponent test_world = new WorldComponent(mock_region.GetType());
            Assert.Throws<EnterException>(() => test_world.EnterRegion(0));
           
        }
    }
}
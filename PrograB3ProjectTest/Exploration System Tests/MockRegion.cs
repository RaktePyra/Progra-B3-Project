using PrograB3Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3ProjectTest.Exploration_System_Tests
{
    internal class EnterException : Exception
    {
        public EnterException()
        {
        }
    }

    internal class MockRegion : IRegion
    {
        public void Enter()
        {
            throw new EnterException();
        }
    }
}

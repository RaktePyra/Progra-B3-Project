using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.States
{
    internal class InGameState : IState
    {
        private int _updateCount = 0;
        public InGameState() { }
        public void Enter()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void Update(float delta_time)
        {
           _updateCount++;
            Console.WriteLine("Been Playing for " + _updateCount + " frames");
            Console.WriteLine("Press Escape to quit");
            Console.Clear();
        }
    }
}

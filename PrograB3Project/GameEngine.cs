using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project
{
    internal class GameEngine
    {
        private bool _shouldExit = false;
        public void Run()
        {
            while (!_shouldExit)
            {
                ProcessInput();
                Update();
                Render();
            }
        }
        private void Update()
        {

        }
        private void Render()
        {

        }
        private void ProcessInput()
        {

        }
    }
}

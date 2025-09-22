using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.States
{
    internal interface IState
    {
        public void Enter();

        public void Update(float delta_time);

        public void Render();

        public void ProcessInput(ConsoleKeyInfo key_info);
        public void Exit();
    }
}

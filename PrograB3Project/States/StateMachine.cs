using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.States
{
    internal class StateMachine
    {
        private IState _currentState;

        public StateMachine() 
        { 
        }

        public void Update(float delta_time)
        {
            _currentState.Update(delta_time);
        }
        public void SetInitialState(IState initial_state)
        {
            _currentState = initial_state;
            _currentState.Enter();
        }

        public void ChangeState(IState new_state)
        {
            _currentState.Exit();
            _currentState = new_state;
            _currentState.Enter();
        }

        public void ProcessInput(ConsoleKeyInfo key_info)
        {
            _currentState.ProcessInput(key_info);
        }
    }
}

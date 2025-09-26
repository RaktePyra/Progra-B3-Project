using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.States
{
    public class StateMachine
    {
        private IState _currentState;
        private IState _initialState;
        private Context _gameContext;
        private bool _hasBeenInitialized = false;

        public StateMachine(Context game_context) 
        { 
            _gameContext = game_context;
        }

        public void Update(float delta_time)
        {
            _currentState.Update(delta_time);
        }
        public void SetInitialState(IState initial_state)
        {
            _currentState = initial_state;
            _initialState = initial_state;
            _hasBeenInitialized = true;
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
        public void Render()
        {
            _currentState.Render();
        }

        public void Refresh()//This method's only purpose is to refresh the render of the state machine upon reentry while staying in the same state
        {
            _currentState = _initialState;
            _initialState.Enter();
        }

        public bool IsInitialized()
        {
            return _hasBeenInitialized;
        }

    }
}

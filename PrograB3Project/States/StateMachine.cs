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
        private Interfaces.IGameEngine _engine;
        private Interfaces.IEventManager _eventManager;
        private bool _hasBeenInitialized = false;

        public StateMachine(Interfaces.IGameEngine engine, Interfaces.IEventManager event_manager) 
        { 
            _engine = engine;
            _eventManager = event_manager;
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

        public void Refresh()//This method's only purpose is to refresh the render of the state machine upon reentry while staying in the same state
        {
            _currentState = _initialState;
            _initialState.Enter();
        }

        public bool IsInitialized()
        {
            return _hasBeenInitialized;
        }

        public Interfaces.IGameEngine GetGameEngine()
        {
            return _engine;
        }

        public Interfaces.IEventManager GetEventManager()
        {
            return _eventManager;
        }
    }
}

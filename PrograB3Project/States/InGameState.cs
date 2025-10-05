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
        private StateMachine _stateMachine;
        private Game _game;
        private bool _isGameRunning = false;

        public InGameState(StateMachine state_machine,RenderManager render_manager,CollisionManager collision_manager) 
        {
            _stateMachine = state_machine;
            _game = new Game(state_machine.GetGameEngine(),state_machine.GetEventManager(), render_manager,collision_manager);
        }

        public void Enter()
        {
            if (!_isGameRunning)
            {
                _isGameRunning=true;
                _game.Run();
            }
        }

        public void Exit()
        {
           
        }

        public void ProcessInput(ConsoleKeyInfo key_info)
        {
            //Exiting is treated inside the Engine
        }

        public void Render()
        {
        }

        public void Update(float delta_time)
        {
           _updateCount++;
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.States
{
    internal class ShopBuyingState : IState
    {
        private StateMachine _shopStateMachine;
        private Context _gameContext;
        public ShopBuyingState(StateMachine state_machine, Context game_context) 
        {
            _shopStateMachine = state_machine;
            _gameContext = game_context;
        }
        public void Enter()
        {
         
        }

        public void Exit()
        {
         
        }

        public void ProcessInput(ConsoleKeyInfo key_info)
        {
            
        }

        public void Render()
        {
          
        }

        public void Update(float delta_time)
        {
           
        }
    }
}

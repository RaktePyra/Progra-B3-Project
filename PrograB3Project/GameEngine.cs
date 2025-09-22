using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrograB3Project.States;

namespace PrograB3Project
{
    internal class GameEngine
    {
        private bool _shouldExit = false;
        private Stopwatch _stopwatch = new Stopwatch();
        private float _loopStartTime = 0;
        private float _elapsedTime = 0;
        private float _lag = 0;
        private const float MS_PER_FRAME = 16;
        private List<GameObject> _gameObjectTable = new List<GameObject>();
        private StateMachine _gameStateMachine;
        public void Run()
        {
            _stopwatch.Start();

            while (!_shouldExit)
            {
                _loopStartTime = _stopwatch.ElapsedMilliseconds;
                ProcessInput();
                while (_lag >= MS_PER_FRAME)
                {
                    FixedUpdate(MS_PER_FRAME);
                    _lag-=MS_PER_FRAME;
                }
                Update(_elapsedTime);
                Render();
                _elapsedTime = _stopwatch.ElapsedMilliseconds-_loopStartTime;
                _lag += _elapsedTime;
            }
        }

        private void FixedUpdate(float delta_time)
        {

        }

        private void Update(float delta_time)
        {
            foreach (GameObject gameObject in _gameObjectTable)
            {
                gameObject.Update(delta_time);
            }
        }

        private void Render()
        {

        }

        private void ProcessInput()
        {
            if(Console.KeyAvailable)
            {
                foreach(GameObject gameObject in _gameObjectTable)
                {
                    
                }
            }
        }
    }
}

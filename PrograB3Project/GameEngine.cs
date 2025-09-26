using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrograB3Project.Components;
using PrograB3Project.States;

namespace PrograB3Project
{
    public class GameEngine
    {
        private bool _shouldExit = false;
        private Stopwatch _stopwatch = new Stopwatch();
        private float _loopStartTime = 0;
        private float _elapsedTime = 0;
        private float _lag = 0;
        private const float MS_PER_FRAME = 16;
        private List<GameObject> _gameObjectTable = new List<GameObject>();
        //private StateMachine _gameStateMachine;
        private Game _game;
        //To refactor later
        private InputComponent _player_input_comp;
        
        public void Run()
        {
            _game = new Game(this);
            _game.Run();
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
            //_gameStateMachine.Update(delta_time);
        }

        private void Render()
        {
            //_gameStateMachine.Render();
            //Console.Clear();
        }

        private void ProcessInput()
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    _shouldExit = true;
                }
                else
                {
                    _player_input_comp.ProcessInput(key);
                }
               // _gameStateMachine.ProcessInput(key);
            }
        }

        public void RegisterGameObject(GameObject game_object)
        {
           if(!_gameObjectTable.Contains(game_object))
            {
                _gameObjectTable.Add(game_object);
            }
        }
        public void UnregisterGameObject(GameObject game_object)
        {
            if (_gameObjectTable.Contains(game_object))
            {
                _gameObjectTable.Remove(game_object);
            }
        }

        public void SetPlayer(GameObject player)
        {
            _player_input_comp = player.GetComponent<InputComponent>();
        }
    }
}

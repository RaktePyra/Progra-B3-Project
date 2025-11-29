using PrograB3Project.Events;
using PrograB3Project.States;
using System.Diagnostics;

namespace PrograB3Project
{
    public class GameEngine : Interfaces.IGameEngine
    {
        private bool _shouldExit = false;
        private Stopwatch _stopwatch = new Stopwatch();
        private float _loopStartTime = 0;
        private float _elapsedTime = 0;
        private float _lag = 0;
        private const float MS_PER_FIXED_UPFATE = 16;
        private const float MS_PER_FRAME = 100;
        private List<GameObject> _gameObjectTable = new List<GameObject>();
        private Queue<GameObject> _gameObjectRegisterTable = new Queue<GameObject>();
        private StateMachine? _gameMachine;
        private Interfaces.IEventManager _eventManager = new Events.EventManager();
        private RenderManager _renderManager = new RenderManager();
        private CollisionManager _collisionManager = new CollisionManager();

        public void Run()
        {
            _eventManager.RegisterEvent<Events.QuitGameEvent>(OnQuitGame);
            _gameMachine = new StateMachine(this, _eventManager);
            _gameMachine.SetInitialState(new MainMenuState(_gameMachine, this, _eventManager, _renderManager, _collisionManager));
            _stopwatch.Start();

            while (!_shouldExit)
            {
                _loopStartTime = _stopwatch.ElapsedMilliseconds;
                ProcessInput();

                while (_lag >= MS_PER_FIXED_UPFATE)
                {
                    FixedUpdate(MS_PER_FIXED_UPFATE);
                    _lag -= MS_PER_FIXED_UPFATE;
                }
                Update(_elapsedTime);
                Render();
                DequeueGameObjects();
                _elapsedTime = _stopwatch.ElapsedMilliseconds - _loopStartTime;

                if (_elapsedTime < MS_PER_FRAME)
                {
                    Thread.Sleep((int)(MS_PER_FRAME - _elapsedTime));
                    _elapsedTime = MS_PER_FRAME;
                }
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
            _renderManager.Render();
        }

        private void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    _shouldExit = true;
                }
                else
                {
                    _eventManager.TriggerEvent(new Events.InputEvent(key));
                }
            }
        }

        public void RegisterGameObject(GameObject game_object)
        {
            if (!_gameObjectTable.Contains(game_object))
            {
                _gameObjectRegisterTable.Enqueue(game_object);
            }
        }
        public void UnregisterGameObject(GameObject game_object)
        {
            if (_gameObjectTable.Contains(game_object))
            {
                _gameObjectTable.Remove(game_object);
            }
        }

        public void OnQuitGame(Event quit_game_event)
        {
            _shouldExit = true;
        }

        private void DequeueGameObjects()
        {
            while (_gameObjectRegisterTable.Count > 0)
            {
                _gameObjectTable.Add(_gameObjectRegisterTable.Dequeue());
            }
        }
    }
}

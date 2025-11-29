using PrograB3Project.Events;
using PrograB3Project.States;
using System;
using System.Collections.Generic;
namespace PrograB3Project
{
    public class GameEngine : Interfaces.IGameEngine
    {
        private List<GameObject> _gameObjectTable = new List<GameObject>();
        private Queue<GameObject> _gameObjectRegisterTable = new Queue<GameObject>();
        private StateMachine? _gameMachine;
        private Interfaces.IEventManager _eventManager = new Events.EventManager();
        private CollisionManager _collisionManager = new CollisionManager();

        public void Run()
        {
            _eventManager.RegisterEvent<Events.QuitGameEvent>(OnQuitGame);
            _gameMachine = new StateMachine(this, _eventManager);
            _gameMachine.SetInitialState(new MainMenuState(_gameMachine, this, _eventManager, _collisionManager));
        }

        public void FixedUpdate(float delta_time)
        {

        }

        public void Update(float delta_time)
        {
            foreach (GameObject gameObject in _gameObjectTable)
            {
                gameObject.Update(delta_time);
            }
        }

        public void Render()
        {
        }

        public void ProcessInput(ConsoleKeyInfo consoleKey)
        {
            _eventManager.TriggerEvent(new Events.InputEvent(consoleKey));
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
        }

        public void DequeueGameObjects()
        {
            while (_gameObjectRegisterTable.Count > 0)
            {
                _gameObjectTable.Add(_gameObjectRegisterTable.Dequeue());
            }
        }
        public Interfaces.IEventManager GetEventManager()
        {
            return _eventManager;
        }
    }
}

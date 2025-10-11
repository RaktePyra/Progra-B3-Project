using PrograB3Project.Events;
using PrograB3Project.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3ProjectTest.TestData
{
    internal class MockSavableComponent : PrograB3Project.Interfaces.IComponent, ISavableComponent
    {
        private string _id;
        private EventManager _eventManager;
        public MockSavableComponent(string id, EventManager event_manager) 
        {
            _id = id;
            _eventManager = event_manager;
        }
        
        public string GetID()
        {
            return _id;
        }

        public IGameObject GetOwnerGameObject()
        {
            throw new NotImplementedException();
        }

        public void ProcessInput(ConsoleKeyInfo key)
        {
            throw new NotImplementedException();
        }

        public void RestoreDataFromFile(string data)
        {
            if (data == _id)
            {
                _eventManager.TriggerEvent(new Events.MockEvent());
            }
        }

        public string Save()
        {
            return _id;
        }

        public void Update(float delta_time)
        {
            throw new NotImplementedException();
        }
    }
}

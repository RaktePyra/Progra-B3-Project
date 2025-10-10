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
        public static int _saveCount;

        public string GetID()
        {
            return _saveCount.ToString();
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
            _saveCount--;
        }

        public string Save()
        {
            return _saveCount.ToString();
           _saveCount++;
        }

        public void Update(float delta_time)
        {
            throw new NotImplementedException();
        }
    }
}

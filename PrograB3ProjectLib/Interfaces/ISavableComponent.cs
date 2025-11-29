using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Interfaces
{
    public interface ISavableComponent
    {
        public string Save();
        public void RestoreDataFromFile(string data);

        public string GetID();
    }
}

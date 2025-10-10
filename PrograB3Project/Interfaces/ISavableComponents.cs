using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.Interfaces
{
    public interface ISavableComponents
    {
        public string Save();
        public string RestoreDataFromFile(string data);
    }
}

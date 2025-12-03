using System;
using System.Collections.Generic;
using System.Text;

namespace PrograB3Project.Events
{
    public class InitializeGameEvent : Event
    {
        public FilePaths filePaths;

        public InitializeGameEvent(FilePaths filePaths)
        {
            this.filePaths = filePaths;
        }
           
        public struct FilePaths
        {
            public string dataFilesFolderRelativePath;
        }
    }
}

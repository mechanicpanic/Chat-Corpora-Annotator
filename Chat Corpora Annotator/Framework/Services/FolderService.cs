using System;
using System.IO;

namespace Viewer.Framework.Services
{
    public class FolderService
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public void CheckFolder()
        {

            if (!Directory.Exists(folderPath + "\\CCA"))
            {
                Directory.CreateDirectory(folderPath + "\\CCA");

            }
        }
        public void CheckModelFolder() { }
    }
}

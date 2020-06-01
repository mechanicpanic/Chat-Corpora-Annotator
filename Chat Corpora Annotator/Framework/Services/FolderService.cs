using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

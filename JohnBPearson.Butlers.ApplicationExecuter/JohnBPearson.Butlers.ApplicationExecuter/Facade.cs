using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Butlers.QuickLaunch
{
    public class Facade
    {

        private List<IExecutable> _executables;
        public List<IExecutable> Executables
        {
        get
            {
                if(_executables == null)
                {
                _executables = new List<IExecutable>();
                    if(!string.IsNullOrWhiteSpace(_directoryPath))
                    {
                        FindFiles(_directoryPath);
                    }


                }           
                return _executables;
            } 
        }

        private string _directoryPath;
        public Facade(string dirPath)
        {
            _directoryPath = dirPath;
        }



        private void FindFiles(string directoryPath)
        {
            var dir = new System.IO.DirectoryInfo(directoryPath);
            var files = dir.EnumerateFiles();
            foreach (var file in files)
            {var exec = new Executable(file.FullName);
            

               this._executables.Add(exec);

                    
                    }
           // dir.GetFiles()
        }
    }
}

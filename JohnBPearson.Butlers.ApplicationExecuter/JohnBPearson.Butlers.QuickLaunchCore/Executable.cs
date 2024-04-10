using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Butlers.QuickLaunchCore
{
    public class Executable : FileSystemObjectBase, IExecutable
    {


        public Executable(string fullPath) : base(fullPath)
        {

        }

        public override void Run()
        {
            if(string.IsNullOrWhiteSpace(this.FullPath))
            {

                throw new Exception("Must have a valid value for FullPath in this istance. Current value \"\" ");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel
{
    public class InitialIzation : FileSystemObjectBase, IFileSystemObjectBase
    {


        internal InitialIzation(string fullPath, FileInfo info) : base(fullPath, info)
        {

        }

        public override void Run()
        {
          
                throw new Exception("cannot call run on an .ini ");
           
        }
    }
}

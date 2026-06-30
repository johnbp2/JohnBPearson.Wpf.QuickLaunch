using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Wpf.QuickLaunchCore.FileMetaDataModel
{
    internal class InitialIzation : FileSystemObjectBase, IFileSystemObjectBase, IInitialization
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

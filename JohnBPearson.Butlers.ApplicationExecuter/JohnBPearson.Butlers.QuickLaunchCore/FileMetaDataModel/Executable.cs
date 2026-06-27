using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel
{
    public class Executable : FileSystemObjectBase, IFileSystemObjectBase
    {


        internal Executable(string fullPath, FileInfo info) : base(fullPath, info)
        {

        }

        public override void Run()
        {
            if (string.IsNullOrWhiteSpace(FullPath))
            {

                throw new Exception("Must have a valid value for FullPath in this istance. Current value \"\" ");
            }

            System.Diagnostics.Process.Start(FullPath);
        }
    }
}

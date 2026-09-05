using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.FileObjects.FileModel
{
    [Obsolete("This class is obsolete and will be removed in future versions. Please use the new Initialization class instead.")]
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

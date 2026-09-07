using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.FileObjects;

namespace JohnBPearson.FileObjects.Model
{
    internal class Directory : FileSystemObjectBase, IFileSystemObjectBase
    {
        internal Directory(string fullPath, FileInfo info) : base(fullPath, info)
        {

            // TODO: add logic here to call the builder
        }

    
        public override void Run()
        {
            var test = new System.Diagnostics.ProcessStartInfo(this.FullPath, "");
        }

        public IEnumerable<IFileSystemObjectBase> Contents
        {
        get; private set; 
        }
    }
}

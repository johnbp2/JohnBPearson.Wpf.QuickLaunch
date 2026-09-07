using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.FileObjects;

<<<<<<<< HEAD:JohnBPearson.FileObjects/JohnBPearson.FileObjects/Model/Directory.cs
namespace JohnBPearson.FileObjects.Model
========
namespace JohnBPearson.FileObjects.FileModel
>>>>>>>> f7d82559a00f21c7dc12d9aeb98277b27b5e9ddd:JohnBPearson.FileObjects/JohnBPearson.FileObjects/FileModel/Directory.cs
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

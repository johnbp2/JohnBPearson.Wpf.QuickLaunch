using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:JohnBPearson.FileObjects/JohnBPearson.FileObjects/Model/Initialization.cs
namespace JohnBPearson.FileObjects.Model
========
namespace JohnBPearson.FileObjects.FileModel
>>>>>>>> f7d82559a00f21c7dc12d9aeb98277b27b5e9ddd:JohnBPearson.FileObjects/JohnBPearson.FileObjects/FileModel/Initialization.cs
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

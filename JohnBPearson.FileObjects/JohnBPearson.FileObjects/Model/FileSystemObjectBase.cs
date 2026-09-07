using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.FileObjects;
using CustomExtensions;

<<<<<<<< HEAD:JohnBPearson.FileObjects/JohnBPearson.FileObjects/Model/FileSystemObjectBase.cs
namespace JohnBPearson.FileObjects.Model
========
namespace JohnBPearson.FileObjects.FileModel
>>>>>>>> f7d82559a00f21c7dc12d9aeb98277b27b5e9ddd:JohnBPearson.FileObjects/JohnBPearson.FileObjects/FileModel/FileSystemObjectBase.cs
{

    public abstract class FileSystemObjectBase : IFileSystemObjectBase
    {
      

        private string _fullPath = "";
        public string FullPath
        {
            get
            {
                return _fullPath;
            }
            private set
            {
                _fullPath = value;
            }
        }
        public string ParentPath
        {
            get
            {
                return Path.GetDirectoryName(FullPath);
            }
        }
        private string _name = string.Empty;
        public string Name
        {
            get
            {
                return _name;
            }
        }

        private string _extension = string.Empty;
        public string Extension
        {
            get
            {
                return _extension;
            }
            private set
            {
                if (value != _extension && !string.IsNullOrEmpty(value))
                {
                    _extension = value;
                }
            }
        }


        private Icon _icon;
        public Icon Icon
        {
            get
            {
                return _icon;
            }
            private set
            {
                if (value != null)
                {

                    _icon = value;
                }
            }
        }

        private FileExtensionEnum _type;

        public FileExtensionEnum Type
        {
            get
            {
                return _type;
            }
        }


        //  todo add validation patterns


        protected FileSystemObjectBase(string fullPath, FileInfo info)
        {
            // var unknkownFileSystemObject = new System.IO.FileInfo(fullPath);
            FullPath = fullPath;
            Extension = info.Extension;
            _name = info.Name;
            foreach(var ext in FileExtensionHelper.Extensions)
            {
                if(ext.Item1 == Extension)
                {
                    //MyEnum myEnum = (MyEnum)myInt;

                    //MyEnum myEnum = (MyEnum)Enum.Parse(typeof(MyEnum), myString);
                    object objOut;
                    if(Enum.TryParse(typeof(FileExtensionEnum), Extension.SanitizeFileExtension(),out objOut)){
                        var extension = (FileExtensionEnum)objOut;
                        this.settheType(extension);
                        break;
                    }
                   
                }
            }
  
     
<<<<<<<< HEAD:JohnBPearson.FileObjects/JohnBPearson.FileObjects/Model/FileSystemObjectBase.cs
            if(this.Type != Model.FileExtensionEnum.dir)
========
            if(this.Type != FileModel.FileExtensionEnum.dir)
>>>>>>>> f7d82559a00f21c7dc12d9aeb98277b27b5e9ddd:JohnBPearson.FileObjects/JohnBPearson.FileObjects/FileModel/FileSystemObjectBase.cs
            {
                this._icon = System.Drawing.Icon.ExtractAssociatedIcon(fullPath);
            }

      
        }
        void settheType(FileExtensionEnum type)
        {
            _type = type;
        }

        public abstract void Run();


    }
}

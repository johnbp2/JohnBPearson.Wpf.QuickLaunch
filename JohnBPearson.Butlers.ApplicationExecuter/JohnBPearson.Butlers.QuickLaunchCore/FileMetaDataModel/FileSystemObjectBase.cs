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
using JohnBPearson.Wpf.QuickLaunchCore;
using CustomExtensions;

namespace JohnBPearson.Wpf.QuickLaunchCore.FileMetaDataModel
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
                    if(Enum.TryParse(typeof(FileExtensionEnum), Extension.CleanseFileExtension(),out objOut)){
                        var extension = (FileExtensionEnum)objOut;
                        this.settheType(extension);
                        break;
                    }
                   
                }
            }
  
     
            if(this.Type != FileMetaDataModel.FileExtensionEnum.dir)
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

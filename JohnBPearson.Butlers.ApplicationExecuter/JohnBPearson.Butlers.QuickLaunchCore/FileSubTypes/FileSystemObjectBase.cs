2using Microsoft.SqlServer.Server;
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
using JohnBPearson.Butlers.QuickLaunchCore;
using CustomExtensions;

namespace JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel
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

        private Extension _type;

        public Extension Type
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
            foreach(var ext in FileExtension.Extensions)
            {
                if(ext.Item1 == Extension)
                {
                    //MyEnum myEnum = (MyEnum)myInt;

                    //MyEnum myEnum = (MyEnum)Enum.Parse(typeof(MyEnum), myString);
                    object objOut;
                    if(Enum.TryParse(typeof(Extension), Extension.CleanseFileExtension(),out objOut)){
                        var extension = (Extension)objOut;
                    }
                   
                }
            }
            
            void settheType(Extension type)
            {
                _type = type;
            }
            if(this.Type != FileMetaDataModel.Extension.dir)
            {
                this._icon = System.Drawing.Icon.ExtractAssociatedIcon(fullPath);
            }

      
        }


        public abstract void Run();


    }
}

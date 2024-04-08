using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Butlers.QuickLaunch
{
    public enum FileSystemObjectType
    {
        File = 0, ExecutableFile = 1, Directory = 2,
    }

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
                return this._name;
            }
        }

        private string _extension = string.Empty;
        public string Extension
        {
            get
            {
                return this._extension;
            }
            private set
            {
                if(value != this._extension && !string.IsNullOrEmpty(value))
                {
                    this._extension = value;
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
                if(value != null)
                {

                    this._icon = value;
                }
            }
        }

        private FileSystemObjectType _type;

        public FileSystemObjectType Type
        {
            get
            {
                return this._type;
            }
        }


        public FileSystemObjectBase(string fullPath)
        {
            FullPath = fullPath;

            var someFilertDirObject = new System.IO.FileInfo(fullPath);
            this.Extension = someFilertDirObject.Extension;
            if(string.IsNullOrWhiteSpace(Extension))
            {
                this._type = FileSystemObjectType.Directory;
            }
            else if(this.Extension.Trim().ToLower() == "exe")
            {

                this._type = FileSystemObjectType.ExecutableFile;
            }
            else
            {
                this._type = FileSystemObjectType.File;
            }

            this._name = someFilertDirObject.Name;

            if(this.Type != FileSystemObjectType.Directory)
            {
                this._icon = System.Drawing.Icon.ExtractAssociatedIcon(fullPath);
            }
        }


        public abstract void Run();


    }
}

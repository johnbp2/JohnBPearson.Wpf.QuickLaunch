using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Butlers.QuickLaunchCore
{
    public enum FileSystemObjectType
    {
        File = 0, ExecutableFile = 1, Directory = 2, BinaryLinkFormat = 3
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
        todo add validation patterns

        public FileSystemObjectBase(string fullPath)
        {
            FullPath = fullPath;

            var unknkownFileSystemObject = new System.IO.FileInfo(fullPath);
            this.Extension = unknkownFileSystemObject.Extension;
            // the strange way to check what this is.
            // if directory: Extentsion= String.Empty evaluates true
            // for a file Extension==String.Empty evaluates false
            //  
            if(string.IsNullOrWhiteSpace(Extension))
            {
                this._type = FileSystemObjectType.Directory;
            }
            switch(this._type)
            {
                case FileSystemObjectType.Directory:
                    settheType()
                    break;
                case FileSystemObjectType.File:
                    break;
                case FileSystemObjectType.BinaryLinkFormat:
                    break;
                case FileSystemObjectType.ExecutableFile:
                    this._type = FileSystemObjectType.ExecutableFile;
                    break;
                default:
                    break;
            }
            void settheType(FileSystemObjectType type)
            {
                this._type = type;
            }
            //else if(this.Extension.Trim().ToLower() == ".exe")
            //{

            //    this._type = FileSystemObjectType.ExecutableFile;
            //}
            //else
            //{
            //    this._type = FileSystemObjectType.File;
            //}

            //this._name = unknkownFileSystemObject.Name;

            //if(this.Type != FileSystemObjectType.Directory)
            //{
            //    this._icon = System.Drawing.Icon.ExtractAssociatedIcon(fullPath);
            //}

            //if(this.Extension == ".lnk")
            //{
            //  this._fullPath = GetShortcutTarget(this.FullPath);
            //}
        }


        public abstract void Run();

   
    }
}

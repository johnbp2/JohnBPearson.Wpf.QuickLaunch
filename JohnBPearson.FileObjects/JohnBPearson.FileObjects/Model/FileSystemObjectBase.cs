using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CustomExtensions;
using JohnBPearson.FileObjects;
using Microsoft.SqlServer.Server;
using Securify.ShellLink.Structures;


namespace JohnBPearson.FileObjects.Model
{

    internal abstract class FileSystemObjectBase : IFileSystemObjectBase
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
        private int _order = 0;
        public int Order
        {
            get
            {
                return _order;
            }
            private set
            {
                if (value != _order)
                {
                    _order = value;
                }
            }
        }
        public bool IsOrdered
        {
            get
            {
                return _order > 0;
            }
        }
        //  todo add validation patterns


        protected FileSystemObjectBase(string fullPath, FileSystemInfo info)
        {
            // var unknkownFileSystemObject = new System.IO.FileInfo(fullPath);
            FullPath = fullPath;
            Extension = info.Extension;
            _name = info.Name;
            foreach (var ext in FileExtension.Extensions)
            {
                if (ext.Item1 == Extension)
                {

                    object objOut;
                    if (Enum.TryParse(typeof(FileExtensionEnum), Extension.SanitizeFileExtension(), out objOut))
                    {
                        var extension = (FileExtensionEnum)objOut;
                        this.settheType(extension);
                        break;
                    }

                }
            }


            if (this._type != Model.FileExtensionEnum.dir)

            {
                this._icon = System.Drawing.Icon.ExtractAssociatedIcon(fullPath);
            }
            else
            {
                this._icon = new Icon("folder128x128.ico", 32, 32);

            }

            // this checks if the file name contains a number followed by a period at the beginning of the name, and if so, it extracts that number and sets it as the order.
            var rx = new Regex(@"/^\d+[.]/g");
            var match = rx.Match(info.Name);
            if (match.Success)
            {
                var temp = info.Name.Substring(0, info.Name.IndexOf('.'));
                if (int.TryParse(temp, out int order))
                {
                    this.Order = order;
                }
            }
            else { 
                this.Order = 0;
            }

        }
        void settheType(FileExtensionEnum type)
        {
            _type = type;
        }

        public abstract void Run();


    }
}

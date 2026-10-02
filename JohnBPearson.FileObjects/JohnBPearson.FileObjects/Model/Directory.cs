using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExtensions;
using JohnBPearson.FileObjects;
using Securify.ShellLink;


namespace JohnBPearson.FileObjects.Model
{
 

    internal class Directory : FileSystemObjectBase, IFileSystemObjectBase, IDirectory
    {

        private DirectoryInfo _directoryInfo;
        private IEnumerable<IFileSystemObjectBase> _contents;
        internal Directory(string fullPath, DirectoryInfo info) : base(fullPath, info)
        {

            this._directoryInfo = info;
        }


        public override void Run()
        {
            //  var test = new System.Diagnostics.ProcessStartInfo(this.FullPath, "");

            var psi = new ProcessStartInfo
            {
                FileName = this.FullPath,
                UseShellExecute = true
            }
            ;
            System.Diagnostics.Process.Start(psi);

        }

        public IEnumerable<IFileSystemObjectBase> Contents
        {
            get {
                if(_contents == null)
                {
                 _contents=  this.InstantiateFileSystemObjects(_directoryInfo.FullName);
                } 
            return      _contents;
            } private set {
                _contents = value;
            }
        }



        private  IEnumerable<IFileSystemObjectBase> InstantiateFileSystemObjects(string directoryPath)
        {
            var items = new List<IFileSystemObjectBase>();
            //var dir = new System.IO.DirectoryInfo(directoryPath);
            if(this._directoryInfo != null && this._directoryInfo.Exists)
            {
                var fact = new FileSystemObjectFactory();
                var files = this._directoryInfo.EnumerateFiles();
                foreach(var file in files)
                {
                    if(file.Extension == Constants.lnk)
                    {

                        try
                        {

                            var sc = Shortcut.ReadFromFile(file.FullName);

                            if(sc.LinkFlags.HasFlag(Securify.ShellLink.Flags.LinkFlags.HasLinkInfo))
                            {
                                AddFileToObjects(file, ref items);
                            }

                        }
                        catch(ArgumentException ex)
                        {

                            // swallow it for now
                        }

                    }
                    else if(FileExtension.ExtensionStrings.Contains(file.Extension.SanitizeFileExtension()))


                    {

                        AddFileToObjects(file, ref items);
                    }
                }

                // dir.GetFiles()
            }
            return items;

        }

        private  void AddFileToObjects(System.IO.FileInfo file, ref List<IFileSystemObjectBase> items)
        {
            var fileObject = FileSystemObjectFactory.Build(file.FullName, file);
            if(fileObject != null)
            {
                items.Add(fileObject);
            }
        }

    }
}

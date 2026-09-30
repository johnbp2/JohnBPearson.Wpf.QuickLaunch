using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.FileObjects.Model;

namespace JohnBPearson.FileObjects
{

    /// <summary>
    /// this should be the public facing api for this module
    /// </summary>
    public class FileSystemObjectFactory
    {

        public FileSystemObjectFactory()
        {
        }


        public static IFileSystemObjectBase Build(string path, FileSystemInfo fileInfo)
        {
            var unknkownFileSystemObject = fileInfo;

            if(string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("path cannot be emtpy", "path");
            }
       //     var unknkownFileSystemObject = new System.IO.FileInfo(path);
            if(!unknkownFileSystemObject.Exists)
            {
            throw new FileNotFoundException(path);
            }
            var extension = unknkownFileSystemObject.Extension;
            //foreach(var item in Constants.getEnumerator())
            //{
            //    if(extension == item)1
            //    {
            //    Activator.CreateInstance(TypeOf)
            //    }
            //}
        
            // the strange way to check what this is.
            // if directory: Extentsion= String.Empty evaluates true
            // for a file FileExtensionEnum==String.Empty evaluates false
            //  
           
            switch(extension)
            {
                case Constants.dir:

                    return new JohnBPearson.FileObjects.Model.Directory(path, unknkownFileSystemObject as DirectoryInfo);
                    
                
                case Constants.lnk:
                    return new JohnBPearson.FileObjects.Model.BinaryLinkFormat(path, unknkownFileSystemObject as FileInfo);

                   
                case Constants.exe:
                    return new JohnBPearson.FileObjects.Model.BinaryLinkFormat(path, unknkownFileSystemObject as FileInfo);
                //case Constants.ini:
                //    return new JohnBPearson.FileObjects.Model.InitialIzation(path, unknkownFileSystemObject);
                case Constants.url:
                    return new JohnBPearson.FileObjects.Model.Url(path, unknkownFileSystemObject as FileInfo);
                default:
                    return null;
                   
            }
           

        }
    }
}

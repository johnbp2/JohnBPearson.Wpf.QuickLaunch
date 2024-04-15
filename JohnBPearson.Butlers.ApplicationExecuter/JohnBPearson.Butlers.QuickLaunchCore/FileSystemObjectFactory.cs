using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel;

namespace JohnBPearson.Butlers.QuickLaunchCore
{

    /// <summary>
    /// this should be the public facing api for this module
    /// </summary>
    public class FileSystemObjectFactory
    {

        public FileSystemObjectFactory()
        {
        }


        public static FileMetaDataModel.IFileSystemObjectBase Build(string path, FileInfo fileInfo)
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
            // the strange way to check what this is.
            // if directory: Extentsion= String.Empty evaluates true
            // for a file Extension==String.Empty evaluates false
            //  
           
            switch(extension)
            {
                case Constants.dir:
                    return new JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel.Directory(path, unknkownFileSystemObject);
                    
                
                case Constants.lnk:
                    return new JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel.BinaryLinkFormat(path, unknkownFileSystemObject);

                   
                case Constants.exe:
                    return new JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel.BinaryLinkFormat(path, unknkownFileSystemObject);
                case Constants.ini:
                    return new JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel.InitialIzation(path, unknkownFileSystemObject);
                default:
                    return null;
                   
            }
           

        }
    }
}

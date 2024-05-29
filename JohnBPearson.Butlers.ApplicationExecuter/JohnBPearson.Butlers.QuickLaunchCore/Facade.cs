using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel;

namespace JohnBPearson.Butlers.QuickLaunchCore
{
    public class Facade
    {


        private List<IFileSystemObjectBase> _executables;


        public List<IFileSystemObjectBase> FileSystemObjects
        {
            get
            {
                if(_executables == null)
                {
                    _executables = new List<IFileSystemObjectBase>();
                    if(!string.IsNullOrWhiteSpace(_directoryPath))
                    {
                        InstantiateFileSystemObjects(_directoryPath);
                    }


                }
                return _executables;
            }
        }

        private string _directoryPath;
        public Facade(string dirPath)
        {

            if(this.isStringValidDir(dirPath))
            {

                _directoryPath = dirPath;
            }
        }
        public void RefreshFileSystemObjects()
        {
            this.InstantiateFileSystemObjects(_directoryPath);
        }
        private void InstantiateFileSystemObjects(string directoryPath)
        {
            var dir = new System.IO.DirectoryInfo(directoryPath);
            if(dir.Exists)
            {
                var fact = new FileSystemObjectFactory();
                var files = dir.EnumerateFiles();
                foreach(var file in files)
                {
                    var fileObject = FileSystemObjectFactory.Build(file.FullName, file);
                    if(fileObject != null)
                    {
                        this.FileSystemObjects.Add(fileObject);
                    }
                    //var exec = new Executable(file.FullName);
                    //FileSystemObjectBase.Build(file.FullName)

                    //  _executables.Add(exec);


                }

                // dir.GetFiles()
            }


        }
        private bool isStringValidDir(string dirPath)
        {
            if(string.IsNullOrWhiteSpace(dirPath))
            {

                return false;
            }
            var test = new System.IO.DirectoryInfo(dirPath);
            if(test.Exists)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }


}

namespace CustomExtensions
{

    //Extension methods must be defined in a static class
    public static class StringExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static string CleanseFileExtension(this string str)
        {
            if(str.Contains('.') && str.Length == 4 && str.StartsWith("."))
            {
                return str.Substring(1, 3);
            }
            return str;
        }

        public static string ConvertWhitespacesToSingleSpaces(this string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }
    }
}
